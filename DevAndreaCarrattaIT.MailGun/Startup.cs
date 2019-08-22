
using DevAndreaCarrattaIT.MailGun;
using DevAndreaCarrattaIT.MailGun.Lib;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]

namespace DevAndreaCarrattaIT.MailGun
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {

            var config = new ConfigurationBuilder()
                     .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables()
                     .Build();

            builder.Services.AddSingleton<MailGunEngine>( s=> new MailGunEngine());

            builder.Services.AddSingleton<MailGunConfig>(s =>
            {
                var c = s.GetService<IConfiguration>();

                var mailGunConfig = new MailGunConfig()
                {
                    ApiBaseUri = config[Const.ApiBaseUri],
                    ApiKey = config[Const.ApiKey],
                    Domain = config[Const.Domain],
                    Expression = config[Const.Expression],
                    FromMail = config[Const.FromMail],
                    FromName = config[Const.FromName],
                };

                bool addHeaderNativeSend = false;
                bool.TryParse(config[Const.AddHeaderNativeSend], out addHeaderNativeSend);
                mailGunConfig.AddHeaderNativeSend = addHeaderNativeSend;

                return mailGunConfig;
            });
        }
    }
}
