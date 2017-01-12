# chayns® Backend API [v2.0]
The backend API provides additional possibilites on top of the frontend API. To use this API, the tapp must be registered in the Tapp administration in the [TSPN](https://en.tspn.tobit.software). After the registration the Tapp Secret is needed for the authorization on request to the API. 

### General
The requests in frontend and backend have the same structure. For the authorization you can use the Tapp Secret along with the TappID in the backend or a PageAccessToken in the frontend, but like above mentioned, you shouldn't use the Tapp Secret in the frontend. 

<b>The current API version is 2.0.</b>

The request structure looks like

```
https://api.chayns.net/{APIVersion}/{LocationID}/{Controller}/{ObjectID}
```(the ObjectID parameter is optional).


Parameters in following examples explained

* LocationID - int: The ID of the current location. It is contained in chayns.env.site.locationId.
* TappID - int: The ID of the current tapp. It is contained in chayns.env.site.tapp.id and used in the Authorization header.

### Preparation
To use the chayns® Backend API, you have to register your Tapp in the Tapp Administration on TSPN. With the registration, you will get an Tapp Secret. This secret is very important and you shouldn't use your secret in your frontend!  
All API calls will be verified by the Tapp Secret along with the TappID or a PageAccessToken. If you want to send requests from the frontend, you have to use a PageAccessToken. 

To get an PageAccessToken you have to run a POST (HTTP) request. You have to set the Content-Type to 'application/json' and add a Authorization header, with the following scheme ```'Basic ' + Base64String(TappID:Tapp Secret)```

The request-body has to contain a string-array of permissions for the requested AccessToken, named 'permissions'.
```
permissions = ['PublicInfo', 'UserInfo', 'DeviceInfo', 'SeeUAC', 'EditUAC', 'Push', 'Email'];
```

The request will return an JSON-Object, that contains an string-array named 'data'. The first item of the array is the PageAccessToken.
