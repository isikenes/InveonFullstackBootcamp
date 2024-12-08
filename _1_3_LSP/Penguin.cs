namespace _1_3_LSP
{
    public class Penguin : Bird
    {
        public override void Fly()
        {
            throw new Exception("Penguins can't fly");
        }
    }
}
