using DevAndreaCarrattaIT.MailGun.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevAndreaCarrattaIT.MailGun
{
    public class Send
    {

        private MailGunEngine _mailGunEngine = null;

        public Send(MailGunConfig mailGunConfig, MailGunEngine mailGunEngine)
        {
            if (mailGunEngine == null)
            {
                throw new System.ArgumentNullException(nameof(mailGunEngine));
            }

            if (mailGunConfig == null)
            {
                throw new System.ArgumentNullException(nameof(mailGunConfig));
            }

            _mailGunEngine = mailGunEngine;

            MailGunConfiguration(mailGunConfig);
        }

        [FunctionName("Send")]
        public async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            if (requestBody == null)
            {
                throw new System.ArgumentNullException(nameof(requestBody));
            }

            MailGunRequest data = JsonConvert.DeserializeObject<MailGunRequest>(requestBody);

            if (data == null)
            {
                throw new System.ArgumentNullException(nameof(data));
            }

            string mailgunResult = _mailGunEngine.Send(
                data.Subject,
                data.Text,
                data.BodyHtml,
                data.To,
                data.Cc,
                data.Ccn);

            string result = JsonConvert.SerializeObject(new { MailGunEngineResult = mailgunResult });

            return result;

        }

        private void MailGunConfiguration(MailGunConfig mailGunConfig)
        {
            _mailGunEngine.AddHeaderNativeSend = mailGunConfig.AddHeaderNativeSend;
            _mailGunEngine.ApiBaseUri = mailGunConfig.ApiBaseUri;
            _mailGunEngine.ApiKey = mailGunConfig.ApiKey;
            _mailGunEngine.Domain = mailGunConfig.Domain;
            _mailGunEngine.Expression = mailGunConfig.Expression;
            _mailGunEngine.FromMail = mailGunConfig.FromMail;
            _mailGunEngine.FromName = mailGunConfig.FromName;
        }

    }
}