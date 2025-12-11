import com.sun.net.httpserver.HttpServer;
import com.google.gson.Gson; // Richiede la libreria Gson esterna
import java.io.IOException;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.util.ArrayList;

public class Server {
    public static void main(String[] args) throws IOException {
        // Crea un server sulla porta 8081
        HttpServer server = HttpServer.create(new InetSocketAddress(8081), 0);
        ArrayList<Messaggio> listaMessaggi = new ArrayList<Messaggio>();
        
        Messaggio messaggio1 = new Messaggio(1,"Alessio", "Simone", "Ciao Simone, come stai?");
        listaMessaggi.add(messaggio1);
        Messaggio messaggio2 = new Messaggio(2,"Alessandro", "Riccardo", "Ciao caro compagno!");
        listaMessaggi.add(messaggio2);
        Messaggio messaggio3 = new Messaggio(3,"Carlo", "CarloSSS", "Vorrei anche io la SSS alla fine del nome!");
        listaMessaggi.add(messaggio3);
        
        // Crea un contesto che mappa l'URI /Messaggio/MessaggiosList a un handler
        server.createContext("/Messaggio/MessaggiosList", (exchange) -> {
            
            // 1. Verifica che sia una richiesta GET
            if (!"GET".equals(exchange.getRequestMethod())) {
                exchange.sendResponseHeaders(405, -1); // Metodo non consentito
                return;
            }

            // 3. Serializza l'oggetto in una stringa JSON
            Gson gson = new Gson();
            
            String jsonResponse = gson.toJson(listaMessaggi);

            // 4. Imposta l'header Content-Type e la lunghezza della risposta
            exchange.getResponseHeaders().set("Content-Type", "application/json");
            exchange.sendResponseHeaders(200, jsonResponse.length());

            // 5. Scrive il JSON nel corpo della risposta
            try (OutputStream os = exchange.getResponseBody()) {
                os.write(jsonResponse.getBytes());
            }
        });
        
        // Crea un contesto che mappa l'URI /Messaggio/messaggi/ a un handler
        server.createContext("/Messaggio/messaggi/", (exchange) -> {
            
            // 1. Verifica che sia una richiesta GET
            if (!"GET".equals(exchange.getRequestMethod())) {
                exchange.sendResponseHeaders(405, -1); // Metodo non consentito
                return;
            }

            // 3. Serializza l'oggetto in una stringa JSON...
            Gson gson = new Gson();
            // ...Cerco l'id nel path della richiesta per restituire il messaggio corrispondente
            String path = exchange.getRequestURI().getPath(); // Esempio: "/Messaggio/messaggi/2"
            String[] pathSplit = path.split("/");
            int last = pathSplit.length;
            int id = Integer.parseInt(pathSplit[last-1]);
            String jsonResponse = "";
            for(Messaggio mess : listaMessaggi){
                if(mess.idMessaggio==id){
                    jsonResponse = gson.toJson(mess);
                }
            }
            //jsonResponse = gson.toJson(listaMessaggi.get(id));

            // 4. Imposta l'header Content-Type e la lunghezza della risposta
            exchange.getResponseHeaders().set("Content-Type", "application/json");
            exchange.sendResponseHeaders(200, jsonResponse.length());

            // 5. Scrive il JSON nel corpo della risposta
            try (OutputStream os = exchange.getResponseBody()) {
                os.write(jsonResponse.getBytes());
            }
        });
        
        server.setExecutor(null); // Usa l'executor predefinito
        server.start();
        System.out.println("Server avviato sulla porta 8081. GET http://localhost:8081/Messaggio/MessaggiosList");
    }
}