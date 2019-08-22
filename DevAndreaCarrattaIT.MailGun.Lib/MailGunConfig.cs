namespace DevAndreaCarrattaIT.MailGun.Lib
{
    public class MailGunConfig : IMailGunConfig
    {
        public string ApiBaseUri { get; set; }
        public string ApiKey { get; set; }
        public string Domain { get; set; }
        public string Expression { get; set; }
        public bool AddHeaderNativeSend { get; set; }
        public string FromMail { get; set; }
        public string FromName { get; set; }
    }
}
