# c#-chayns-sample-getLocationInfo
Sample of a c# API using the chayns backend API to get information about a specific chayns location.<br>
This project was made using Visual Studio 2015.

### Setting up the project
1. Go to Project -> Properties -> Web -> Servers<br>
2. In the dropdown menu select the 'Local IIS' and press 'Create Virtual Directory'.<br>
3. Rightclick the solution -> Rebuild
4. The API is now available at http://localhost/LocationInfo/ 
 - If you are using any webserver except the lcoal one, publish the project to this server
5. Rightclick the project -> Publish -> Custom -> Create a publish profile and select your webserver as a publish target

### Packages
This project is using the following packages
* Newtonsoft.Json
* RestSharp