let express = require('express'); //used for handling the request and response. Represents the server in this script
let fetch = require('node-fetch'); //used for performing the fetch to the backend api
let btoa = require('btoa'); //used for base64 encoding for the authorization header. For more information see the wiki at https://github.com/TobitSoftware/chayns-backend/wiki/authorization
let app = express();

let server = app.listen(8080, function() {
    console.log("\nServer is running on 'localhost:8080'\n");
});

const Server = 'https://api.chayns.net/v2.0/';
const Secret = ''; //replace this string with your tapp secret located in the tapp administration

app.get('/LocationInfo', (req, res) => { //Get url parameters using the req-object
    try {
        let url = Server + req.query.locationId; //build the url to request the location endpoint
        let config = {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Basic ' + btoa(req.query.tappId + ':' + Secret) //Building the Auth header. See the wiki for more informationen.
            }
        }
        fetch(url, config).then(response => {
            if (response.status === 200) { 
                response.json().then((data) => {
                    res.send(data); //if the request was successful, send the aquired data to the client
                });
            } else {
                res.send(response.status); //if the request failed, send the http status to the client
            }
        });
    }
    catch(e) {
        res.sendStatus(500);
    }
});