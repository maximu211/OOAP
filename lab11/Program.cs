using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Parallel.Invoke(
            async () => await GetData("https://www.thomann.de/gb/heavy_guitars.html"),
            async () => await GetData("https://www.thomann.de/gb/t_models.html")
        );

        Console.WriteLine("Обидві сторінки товару було оброблено.");

        Console.ReadLine();
    }

    static async Task GetData(string url)
    {
        Console.WriteLine("Отримання даних з першої сторінки товару...");
        string apiUrl = url;

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Дані з першої сторінки товару: {responseBody}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Помилка при виконанні запиту: {ex.Message}");
            }
        }
    }
}
