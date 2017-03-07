# chayns® Backend API [v2.0]
The backend API provides additional possibilites on top of the frontend API. To use this API, the tapp must be registered in the Tapp administration in the [TSPN](https://tspn.tobit.software). After the registration the Tapp Secret is needed for the authorization on requests to the API. 

### General
The requests in frontend and backend have the same structure. For the authorization you can use the Tapp Secret along with the TappID in the backend or a PageAccessToken in the frontend. 

The request structure looks like

```
https://api.chayns.net/{APIVersion}/{LocationID}/{Controller}/{ObjectID}
```
(the ObjectID parameter is optional).

General parameters explained

* APIVersion - string: Compound of the letter 'v' and the API version. So the parameter could look like 'v2.0'.
* LocationID - int: The ID of the current location. It is contained in chayns.env.site.locationId.
* TappID - int: The ID of the current tapp. It is contained in chayns.env.site.tapp.id and used in the Authorization header.

For more detailed information on the Backend API you should take a look at the [Wiki](https://github.com/TobitSoftware/chayns-backend/wiki).
