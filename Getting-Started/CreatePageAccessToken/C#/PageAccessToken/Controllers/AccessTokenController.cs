using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using System.Text;
using System.Web.Http;

namespace PageAccessToken.Controllers
{
    public class AccessTokenController : ApiController //extends the ApiController class as ApiControllers are specialized for returning data to the client
    {
        string Server = "https://api.chayns.net/v2.0/";
        //replace the following string with the tapp secret of your developer tapp
        string Secret = "";

        //Call this controller method with localhost/PageAccessToken/AccessToken?locationId=chayns.env.site.locationId&tappId=chayns.env.site.tapp.id 
        public IHttpActionResult Get(int locationId, int tappId)
        {
            try
            {
                /*
                * The following variable keeps all the permissions that should be available with the created accessToken. 
                * Remember to only set those permissions, you have set in the tapp administration as well.
                */
                string[] permissions = new string[] { "PublicInfo", "UserInfo", "SeeUAC", "EditUAC", "DeviceInfo", "Push", "Intercom", "Email" };

                string authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToString(tappId) + ":" + Secret)); //for more information see the chayns-backend wiki/authorization
                RestClient rc = new RestClient(Server);

                RestRequest rr = new RestRequest(locationId + "/AccessToken", Method.POST); 

                rr.AddHeader("Authorization", "Basic " + authHeader);
                rr.AddHeader("Content-Type", "application/json");
                rr.RequestFormat = DataFormat.Json;
                rr.AddBody(new { Permissions = permissions });

                IRestResponse rs = rc.Execute(rr);  //At this point we already got the response from the chayns backend api

                //If all parameters were set correctly, this should've returned a status 200
                if (rs.StatusCode == HttpStatusCode.OK)
                {
                    dynamic data = JObject.Parse(rs.Content);
                    return Ok(new { PageAccessToken = data.data[0].pageAccessToken });
                }
                else
                {
                    return StatusCode(rs.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}