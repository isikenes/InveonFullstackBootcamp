namespace _2_1_Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UploadFileSync();

            Task upload = UploadFileAsync();

            OtherProcess();

            await upload;
        }

        private static void UploadFileSync()
        {
            Console.WriteLine("File uploading started");
            Thread.Sleep(2000);
            Console.WriteLine("File uploading completed");
        }

        private static async Task UploadFileAsync()
        {
            Console.WriteLine("File uploading started");
            await Task.Delay(2000);
            Console.WriteLine("File uploading completed");
        }

        private static void OtherProcess()
        {
            Console.WriteLine("Other processes are running");
        }
    }
}