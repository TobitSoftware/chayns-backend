# chayns® Backend API [v2.0]
The backend API provides additional possibilites on top of the frontend API. To use this API, the tapp must be registered in the Tapp administration in the [TSPN](https://en.tspn.tobit.software). After the registration the Tapp Secret is needed for the authorization on request to the API. 

### Preparation
To use the chayns® Backend API, you have to register your Tapp in the Tapp Administration on TSPN. With the registration, you will get an Tapp Secret. This secret is very important and you shouldn't use your secret in your frontend!  
All API calls will be verified by the Tapp Secret along with the TappID or a PageAccessToken. If you want to send requests from the frontend, you have to use a PageAccessToken. 

To get an PageAccessToken you have to run a POST (HTTP) request. You have to set the Content-Type to 'application/json' and add a Authorization header, with the following scheme ```'Basic ' + Base64String(TappID:Tapp Secret)```

The request-body has to contain a string-array of permissions for the requested AccessToken, named 'permissions'.
```
permissions = ['PublicInfo', 'UserInfo', 'DeviceInfo', 'SeeUAC', 'EditUAC', 'Push', 'Email'];
```

The request will return an JSON-Object, that contains an string-array named 'data'. The first item of the array is the PageAccessToken.
