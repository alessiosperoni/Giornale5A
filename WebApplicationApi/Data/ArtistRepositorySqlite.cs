using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using SharedClassLibrary;
using WebApplicationApi.Data;

namespace BlazorIjectionValidation.Data
{
    public class ArtistRepositorySqlite : IArtistRepository
    {
        private static string dataSourceString = @"Data Source=Data/Source/chinook.db";
       

        public Artist CreateArtist(string Name)
        {
            Artist newArtist = new Artist();
            SqliteConnection myConnection = new SqliteConnection(dataSourceString);
            string sqlString = "INSERT INTO tblArtists (Name) VALUES (@ParametroName);";
            SqliteParameter myParameter = new SqliteParameter("@ParametroName", Name);

            SqliteCommand myCommand = new SqliteCommand(sqlString);
            myCommand.Parameters.Add(myParameter);
            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            sqlString = @"select last_insert_rowid()";
            SqliteCommand mySecondCommand = new SqliteCommand(sqlString);
            mySecondCommand.Connection = myConnection;
            int lastId = Convert.ToInt32(mySecondCommand.ExecuteScalar());
            newArtist.IdArtist = lastId;
            newArtist.Name = Name;
            myConnection.Close();
            return newArtist;
        }

        public Artist GetArtist(int Id)
        {
            //creo gli oggetti che mi servono per manipolare il database: 
            //connection: collega il db a c#
            Artist existentArtist = new Artist();
            SqliteConnection myConnection = new SqliteConnection(dataSourceString);
            //creo il command 
            SqliteCommand myCommand = new SqliteCommand("SELECT * FROM tblArtists WHERE idArtist=@par1");
            SqliteParameter myPar = new SqliteParameter("@par1", Id);
            SqliteDataReader myDatareader;
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
            SqliteConnection myConnection = new SqliteConnection(dataSourceString);
            //command: manda in esecuzione una query sql
            SqliteCommand myCommand = new SqliteCommand("SELECT * FROM tblArtists");
            //ospita la tabella che risulta dall'esecuzione del command
            SqliteDataReader myDatareader;

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
