namespace _1_2_OCP
{
    public class NotificationSender
    {
        public void SendNotification(NotificationType notificationType)
        {
            switch (notificationType)
            {
                case NotificationType.Email:
                    Console.WriteLine("Sending email");
                    break;
                case NotificationType.SMS:
                    Console.WriteLine("Sending SMS");
                    break;
                default:
                    throw new ArgumentException("Invalid notification type");
            }
        }
    }
}
