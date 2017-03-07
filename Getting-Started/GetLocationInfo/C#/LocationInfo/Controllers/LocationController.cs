using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using System.Text;
using System.Web.Http;

namespace LocationInfo.Controllers
{
    public class LocationController : ApiController //extends the ApiController class as ApiControllers are specialized for returning data to the client
    {
        string Server = "https://api.chayns.net/v2.0/";
        //replace the following string with the tapp secret of your developer tapp
        string Secret = "";

        //Call this controller method with localhost/LocationInfo/Location?locationId=chayns.env.site.locationId&tappId=chayns.env.site.tapp.id 
        public IHttpActionResult Get(int locationId, int tappId)
        {
            try
            {
                /*
                * Using restClient for building the request. The url is splitted into two parts: RestClient and RestRequest. 
                * Since the base server url is saved above, the second part used in the RestRequest should explain itself.
                */
                RestClient restClient = new RestClient(Server); //set in the variable above
                RestRequest req = new RestRequest(Convert.ToString(locationId)); //This is the second part of the url, aiming at the location enpoint of the backend API

                //More request parameters to be set..
                req.Method = Method.GET;
                req.AddHeader("Content-Type", "application/json");
                req.AddHeader("Authorization",
                    "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToString(tappId) + ':' + Secret))); //for more information see the chayns-backend wiki/authorization
                req.RequestFormat = DataFormat.Json;

                IRestResponse resp = restClient.Execute(req);  //At this point we already got the response from the chayns backend api

                //If all parameters were set correctly, this should've returned a status 200
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    return Ok(JObject.Parse(resp.Content));
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}