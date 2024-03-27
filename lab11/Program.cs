using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Parallel.Invoke(
            async () => await ProcessFirstPage(),
            async () => await ProcessSecondPage()
        );

        Console.WriteLine("Обидві сторінки товару було оброблено.");

        Console.ReadLine();
    }

    static async Task ProcessFirstPage()
    {
        Console.WriteLine("Отримання даних з першої сторінки товару...");
        string apiUrl = "https://www.thomann.de/gb/heavy_guitars.html";

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

    static async Task ProcessSecondPage()
    {
        Console.WriteLine("Отримання даних з другої сторінки товару...");
        string apiUrl = "https://www.thomann.de/gb/headless_guitars.html";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Дані з другої сторінки товару: {responseBody}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Помилка при виконанні запиту: {ex.Message}");
            }
        }
    }
}
