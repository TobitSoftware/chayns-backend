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

* APIVersion - string: Compound of the letter 'v' and the API version. So the parameter could look like 'v2.0'.
* LocationID - int: The ID of the current location. It is contained in chayns.env.site.locationId.
* TappID - int: The ID of the current tapp. It is contained in chayns.env.site.tapp.id and used in the Authorization header.

### chayns® Helper
In order to make it easier to you to use the Backend API, we provide the chayns helper that comes with a lot of helpful features.<br>
More information can be found [here](https://github.com/TobitSoftware/chayns-backend-dotnet).
