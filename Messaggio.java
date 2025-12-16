public class Messaggio {
    public int idMessaggio;
    public String mittente;
    public String destinatario;
    public String testo;
    
    public Messaggio(int idMessaggio, String mittente, String destinatario, String testo){
        this.idMessaggio = idMessaggio;
        this.mittente=mittente;
        this.destinatario = destinatario;
        this.testo=testo;
    }
}