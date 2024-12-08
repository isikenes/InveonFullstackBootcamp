namespace _1_2_OCP
{
    public class EmailNotification : INotification
    {
        public void Send()
        {
            Console.WriteLine("Sending email");
        }
    }
}
