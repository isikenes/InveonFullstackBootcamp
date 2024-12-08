namespace _2_2_TaskClassMethods
{
    public class Program
    {
        public static async Task Main()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Task is running");
            });


            await Task.Delay(100);


            Task<int> number = Task.FromResult(5);
            Console.WriteLine(await number);


            Task task1 = Task.CompletedTask;

            Task task2 = Task.Delay(1000);


            Task temp = Task.WhenAny(task1, task2);
            try
            {
                temp.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (temp.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("One of the tasks completed successfully");
            else if (temp.Status == TaskStatus.Faulted)
                Console.WriteLine("One of the tasks failed");
            else if (temp.Status == TaskStatus.Canceled)
                Console.WriteLine("One of the tasks was canceled");


            temp = Task.WhenAll(task1, task2);
            try
            {
                temp.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (temp.Status == TaskStatus.RanToCompletion)
                Console.WriteLine("All tasks completed successfully");
            else if (temp.Status == TaskStatus.Faulted)
                Console.WriteLine("Some tasks failed");
            else if (temp.Status == TaskStatus.Canceled)
                Console.WriteLine("Some tasks were canceled");


            Task task3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("New task is running");
            });

            Task task4 = Task.FromException(new Exception("Task failed"));
            try
            {
                task4.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            await Task.Yield();

            var cts = new CancellationTokenSource();
            cts.Cancel();
            try
            {
                Task task5 = Task.FromCanceled(cts.Token);
                Console.WriteLine("Task canceled");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(Task.CurrentId);
        }

    }
}