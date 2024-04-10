using Entities.Entities;

HttpResponseMessage response;

HttpClient httpClient = new HttpClient();
Console.WriteLine("Введите тип запроса:");
string requestMethod = Console.ReadLine();

switch (requestMethod)
{
    case "GET":
        response =await httpClient.GetAsync("http://127.0.0.1:8888/");
        var responseText = await response.Content.ReadAsStreamAsync();
        var list = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Processor>>(responseText);
        foreach (var t in list)
        {
            Console.WriteLine(t.Price);
        }

        break;



}












