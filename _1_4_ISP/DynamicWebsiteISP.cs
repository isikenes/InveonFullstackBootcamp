namespace _1_4_ISP
{
    public class DynamicWebsiteISP : IPageShower, IInputTaker, IFormProcesser
    {
        public void ProcessForm()
        {
            Console.WriteLine("Processing form");
        }

        public void ShowPage()
        {
            Console.WriteLine("Showing page");
        }

        public void TakeInput()
        {
            Console.WriteLine("Taking input");
        }
    }
}
