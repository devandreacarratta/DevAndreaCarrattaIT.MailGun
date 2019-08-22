namespace DevAndreaCarrattaIT.MailGun.Lib
{
    public class MailGunRequest
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string BodyHtml { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Ccn { get; set; }
    }
}
