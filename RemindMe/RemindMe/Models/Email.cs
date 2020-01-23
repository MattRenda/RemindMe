using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;

namespace RemindMe.Models
{
    public class Email
    {


        public static void Send(String email)
        {
            SendSimpleMessage(email);
        }


        public static IRestResponse SendSimpleMessage(String email)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", Environment.GetEnvironmentVariable("MAILGUN_API_KEY"));
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "matthewrenda.com", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "<RemindMeMailService@matthewrenda.com>");
            request.AddParameter("to", "<"+email+">");
            request.AddParameter("subject", "Hello Matthew J Renda");
            request.AddParameter("text", "This is a reminder about your event!");
            request.Method = Method.POST;
            return client.Execute(request);
        }


        



    }


}

