namespace _1_2_OCP
{
    public class Program
    {
        static void Main(string[] args)
        {
            // bad example
            NotificationSender notificationSender = new NotificationSender();
            notificationSender.SendNotification(NotificationType.Email);
            notificationSender.SendNotification(NotificationType.SMS);

            // OCP example
            INotification emailNotification = new EmailNotification();
            emailNotification.Send();

            INotification smsNotification = new SMSNotification();
            smsNotification.Send();
        }
    }
}