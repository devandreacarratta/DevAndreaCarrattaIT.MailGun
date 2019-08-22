namespace DevAndreaCarrattaIT.MailGun.Lib
{
    public interface IMailGunConfig
    {
        string ApiBaseUri { get; set; }
        string ApiKey { get; set; }
        string Domain { get; set; }
        string Expression { get; set; }
        bool AddHeaderNativeSend { get; set; }
string FromMail{ get; set; }
        string FromName { get; set; }
    }
}