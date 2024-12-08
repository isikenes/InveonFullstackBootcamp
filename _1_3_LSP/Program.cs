namespace _1_3_LSP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bird eagle = new Eagle();
            Bird penguin = new Penguin();

            eagle.Fly();
            //penguin.Fly(); throws exception

            //LSP
            FlyingBird parrot = new Parrot();
            BaseBird ostrich = new Ostrich();

            parrot.Fly();
            //ostrich.Fly(); does not have fly method
        }
    }
}