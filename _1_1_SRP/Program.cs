namespace _1_1_SRP
{
    public class Program
    {
        static void Main(string[] args)
        {
            // bad example
            AccountCreatorBad accountCreatorBad = new AccountCreatorBad();
            accountCreatorBad.CreateAccount();
            accountCreatorBad.SendVerificationSMS();
            accountCreatorBad.SendVerificationEmail();

            // SRP example
            AccountCreator accountCreator = new AccountCreator();
            Account account = accountCreator.CreateAccount();

            EmailSender emailSender = new EmailSender();
            emailSender.SendVerificationEmail(account);

            SMSSender smsSender = new SMSSender();
            smsSender.SendVerificationSMS(account);
        }
    }
}