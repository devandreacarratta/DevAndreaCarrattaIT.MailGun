using System.Collections.Generic;

namespace DevAndreaCarrattaIT.MailGun.Lib
{
    public interface IMailGunEngine
    {
        string ApiBaseUri { get; set; }
        string ApiKey { get; set; }
        string Domain { get; set; }
        string Expression { get; set; }
        bool AddHeaderNativeSend { get; set; }
        string FromMail { get; set; }
        string FromName { get; set; }
        string Send(string Subject, string Text, string BodyHtml, string To, string Cc = null, string Ccn = null);
    }
}