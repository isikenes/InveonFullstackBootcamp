namespace _1_4_ISP
{
    public class StaticWebsite : Website
    {
        public void ShowPage()
        {
            Console.WriteLine("Showing page");
        }

        public void TakeInput()
        {
            throw new Exception("Static website cannot take input");
        }

        public void ProcessForm()
        {
            throw new Exception("Static website cannot process form");
        }


    }
}
