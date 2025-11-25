using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SharedClassLibrary;
using WebApplicationApi.Data;

namespace BlazorIjectionValidation.Data
{
    public class ArtistRepositoryMySql : IArtistRepository
    {
        private static string dataSourceString = @"Server=127.0.0.1;Port=3306;Database=testdb;Uid=root;Pwd=pippo;";
        /*
         * Creato server tramite docker windows su porta 3306
         * name: mysqltest
         * MYSQL_ROOT_PASSWORD: pippo
         * porta 3306
         * 
         * login da shell:
          docker exec -it mysql-test mysql -uroot -p
         * 
            CREATE DATABASE testdb;
            USE testdb;
            CREATE TABLE tblArtists (
            idArtist INT AUTO_INCREMENT PRIMARY KEY,
            Name VARCHAR(100) NOT NULL
            );
            INSERT INTO tblArtists (Name)
            VALUES 
              ('The Beatles'),
              ('Pink Floyd'),
              ('Led Zeppelin');
         */

        public Artist CreateArtist(string Name)
        {
            Artist newArtist = new Artist();
            MySqlConnection myConnection = new MySqlConnection(dataSourceString);
            string sqlString = "INSERT INTO tblArtists (Name) VALUES (@ParametroName);";
            MySqlParameter myParameter = new MySqlParameter("@ParametroName", Name);

            MySqlCommand myCommand = new MySqlCommand(sqlString);
            myCommand.Parameters.Add(myParameter);
            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            // Recupero dell'ID appena inserito da testare!!!
            long idArtist = myCommand.LastInsertedId;
            newArtist.IdArtist = (int)idArtist;


           
            newArtist.Name = Name;
            myConnection.Close();
            return newArtist;
        }

        public Artist GetArtist(int Id)
        {
            //creo gli oggetti che mi servono per manipolare il database: 
            //connection: collega il db a c#
            Artist existentArtist = new Artist();
            MySqlConnection myConnection = new MySqlConnection(dataSourceString);
            //creo il command 
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM tblArtists WHERE idArtist=@par1");
            MySqlParameter myPar = new MySqlParameter("@par1", Id);
            MySqlDataReader myDatareader;
            myCommand.Connection = myConnection;
            myCommand.Parameters.Add(myPar);
            myConnection.Open();
            myDatareader = myCommand.ExecuteReader();
            myDatareader.Read();
            existentArtist.IdArtist = Id;
            existentArtist.Name = myDatareader["Name"].ToString();
            myConnection.Close();
            return existentArtist;

        }

        public List<Artist> GetArtistsList()
        {
            List<Artist> listaArtisti = new List<Artist>();
            //creo gli oggetti che mi servono per manipolare il database: 
            //connection: collega il db a c#
            MySqlConnection myConnection = new MySqlConnection(dataSourceString);
            //command: manda in esecuzione una query sql
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM tblArtists");
            //ospita la tabella che risulta dall'esecuzione del command
            MySqlDataReader myDatareader;

            myCommand.Connection = myConnection;
            myConnection.Open();
            myDatareader = myCommand.ExecuteReader();
            while (myDatareader.Read())
            {
                int id = Convert.ToInt32(myDatareader["idArtist"]);
                Artist myArtist = GetArtist(id);

                listaArtisti.Add(myArtist);                
            }
            myConnection.Close();

            return listaArtisti;
        }
    }
}
