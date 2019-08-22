using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace DevAndreaCarrattaIT.MailGun.Lib
{
    public class MailGunEngine : IMailGunEngine
    {

        public string ApiBaseUri { get; set; }
        public string ApiKey { get; set; }
        public string Domain { get; set; }
        public string Expression { get; set; }
        public bool AddHeaderNativeSend { get; set; }
        public string FromMail { get; set; }
        public string FromName { get; set; }


        public MailGunEngine()
        {
        }

        public string Send(string Subject, string Text, string BodyHtml, List<string> To, List<string> Cc = null, List<string> Ccn = null)
        {

            if (Cc == null)
            {
                Cc = new List<string>();
            }

            if (Ccn == null)
            {
                Ccn = new List<string>();
            }

            // Nuget : RestSharp 
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(this.ApiBaseUri);
            client.Authenticator = new HttpBasicAuthenticator("api", this.ApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", this.Domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", $"{FromName} <{FromMail}>");

            if (AddHeaderNativeSend)
            {
                request.AddHeader("x-mailgun-native-send", "true");
                request.AddParameter("x-mailgun-native-send", true);
                request.AddParameter("o:skip-verification", true);
            }

            if (string.IsNullOrEmpty(this.Expression))
            {
                request.AddParameter("priority", 0);
                request.AddParameter("description", $"Route {Guid.NewGuid()}");
                request.AddParameter("expression", this.Expression);
            }

            foreach (var toMail in To)
            {
                request.AddParameter("to", toMail);
            }

            if (Cc != null)
            {
                foreach (var ccMail in Cc)
                {
                    request.AddParameter("cc", ccMail);
                }
            }

            if (Ccn != null)
            {
                foreach (var ccnMail in Ccn)
                {
                    request.AddParameter("ccn", ccnMail);
                }
            }

            request.AddParameter("subject", Subject);

            if (string.IsNullOrEmpty(Text) == false)
            {
                request.AddParameter("text", Text);
            }

            if (string.IsNullOrEmpty(BodyHtml) == false)
            {
                request.AddParameter("html", $"<html>{BodyHtml}</html>");
            }

            request.Method = Method.POST;
            var executeResult = client.Execute(request);

            string result = executeResult.Content.ToString();

            return result;
        }

    }
}