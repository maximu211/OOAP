using System;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

class Program
{
    static void Main(string[] args)
    {
        Task<Guitar> task1 = GetData(
            "https://www.thomann.de/gb/epiphone_flying_v_korina_aged_natural.htm"
        );
        Task<Guitar> task2 = GetData("https://www.thomann.de/gb/schecter_c_1_sls_elite_fr_afb.htm");

        Parallel.Invoke(() => task1.Wait(), () => task2.Wait());

        Guitar guitar1 = task1.Result;
        Guitar guitar2 = task2.Result;

        Console.WriteLine(guitar1.ToString());
        Console.WriteLine();
        Console.WriteLine(guitar2.ToString());

        Console.ReadLine();
    }

    static async Task<Guitar> GetData(string url)
    {
        Guitar guitar = new Guitar();

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(responseBody);

                HtmlNode h1Node = doc.DocumentNode.SelectSingleNode(
                    "//h1[@class='fx-product-headline product-title__title' and @itemprop='name']"
                );
                guitar.Name = h1Node.InnerText.Trim();

                HtmlNode price = doc.DocumentNode.SelectSingleNode("//div[@class='price']");
                guitar.Price = price.InnerText.Trim();

                List<string> descriptions = new List<string>();
                HtmlNodeCollection descriptionNodes = doc.DocumentNode.SelectNodes(
                    "//span[@class='fx-text fx-text--plus list-item__text']"
                );

                foreach (HtmlNode node in descriptionNodes)
                {
                    descriptions.Add(WebUtility.HtmlDecode(node.InnerText).Trim());
                }

                guitar.Description = descriptions;

                return guitar;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}

class Guitar
{
    public string? Name { get; set; }
    public string? Price { get; set; }
    public List<string> Description { get; set; }

    public override string ToString()
    {
        return $"Назва: {Name}\nЦіна: {Price}\nОпис:\n{string.Join("\n", Description)}";
    }
}
