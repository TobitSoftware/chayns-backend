# chayns® Backend API [v2.0]
The backend API provides additional possibilites on top of the frontend API. To use this API, the tapp must be registered in the Tapp administration in the [TSPN](https://en.tspn.tobit.software). After the registration the Tapp Secret is needed for the authorization on request to the API. 

### General
The requests in frontend and backend have the same structure. For the authorization you can use the Tapp Secret along with the TappID in the backend or a PageAccessToken in the frontend. 

<b>The current API version is 2.0.</b>

The request structure looks like

```
https://api.chayns.net/{APIVersion}/{LocationID}/{Controller}/{ObjectID}
```
(the ObjectID parameter is optional).

Parameters in following examples explained

* LocationID - int: The ID of the current location. It is contained in chayns.env.site.locationId.
* TappID - int: The ID of the current tapp. It is contained in chayns.env.site.tapp.id and used in the Authorization header.

### chayns® helper
