namespace _1_4_ISP
{
    public class Program
    {
        static void Main(string[] args)
        {
            //bad example
            Website dynamicWebsite = new DynamicWebsite();
            dynamicWebsite.ShowPage();
            dynamicWebsite.TakeInput();
            dynamicWebsite.ProcessForm();

            Website staticWebsite = new StaticWebsite();
            staticWebsite.ShowPage();
            //staticWebsite.TakeInput(); this throws an exception
            //staticWebsite.ProcessForm(); this throws an exception

            //ISP
            DynamicWebsiteISP dynamicWebsiteISP = new DynamicWebsiteISP();
            dynamicWebsiteISP.ShowPage();
            dynamicWebsiteISP.TakeInput();
            dynamicWebsiteISP.ProcessForm();

            StaticWebsiteISP staticWebsiteISP = new StaticWebsiteISP();
            staticWebsiteISP.ShowPage();

        }
    }
}