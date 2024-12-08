using System.Text.Json;

namespace _2_3_AsyncExceptionHandling
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await GetBitcoinData();
        }

        static async Task GetBitcoinData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                        {
                            var usdRate = doc.RootElement
                                .GetProperty("bpi")
                                .GetProperty("USD")
                                .GetProperty("rate")
                                .GetString();

                            Console.WriteLine($"Bitcoin: {usdRate} USD");
                        }
                    }
                    else
                    {
                        throw new Exception("Response status is not success");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}