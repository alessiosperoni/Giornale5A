// Esempio di risposta JSON da un server Node.js
const express = require('express');
const app = express();
const messaggi = [
	{
		IdMessaggio: 1,
		Mittente: "Alessio",
		Destinatario: "Simone",
		Testo: "Ciao, come stai?"
	}, {
		IdMessaggio: 2,
		Mittente: "Simone",
		Destinatario: "Alessio",
		Testo: "Bene, grazie. Tu?"
	}, {
		IdMessaggio: 3,
		Mittente: "Alessio",
		Destinatario: "Simone",
		Testo: "Bene anche io!"
	}, {
		IdMessaggio: 4,
		Mittente: "Gnazio",
		Destinatario: "Fisio",
		Testo: "E Tando?"
	}, {
		IdMessaggio: 5,
		Mittente: "Fisio",
		Destinatario: "Gnazio",
		Testo: "Tando no est como"
	}, {
		IdMessaggio: 6,
		Mittente: "Fisio",
		Destinatario: "Gnazio",
		Testo: "Buona!"
	}, {
		IdMessaggio: 7,
		Mittente: "Marco",
		Destinatario: "Luigi",
		Testo: "Ciao Luigi, come stai? Hai studiato TPSIT??"
	}
];
app.get('/Messaggio/messaggi/:id', (req, res) => {
	const idRichiesto = parseInt(req.params.id);
	const messaggioTrovato = messaggi.find(m => m.IdMessaggio == idRichiesto);
	console.log("Rispondo alla richiesta... id:", idRichiesto);
	if (messaggioTrovato) {
		// Se trovato, restituiamo il messaggio con codice 200 OK
		res.send(messaggioTrovato);
	} else {
		// Se NON trovato, restituiamo un errore 404 Not Found
		res.status(404).send({ errore: `Messaggio con ID ${idRichiesto} non trovato.` });
	}

});


app.get('/Messaggio/MessaggiosList', (req, res) => {
	console.log("Rispondo alla richiesta...");
	res.setHeader('Content-Type', 'application/json');
	res.send(JSON.stringify(messaggi));
});

app.listen(3000, () => {
	console.log('Server in ascolto sulla porta 3000');
});
