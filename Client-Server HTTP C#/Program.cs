using Entities.Entities;
using System.Net.Http.Json;

HttpResponseMessage response;

HttpClient httpClient = new HttpClient();

string connection = "http://127.0.0.1:8888/";

Console.WriteLine("Введите тип запроса:");
string requestMethod = Console.ReadLine();

switch (requestMethod)
{
    case "GET":
        response =await httpClient.GetAsync(connection);
        var responseText = await response.Content.ReadAsStreamAsync();
        var employees = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Employee>>(responseText);
        foreach (var empl in employees)
        {
            Console.WriteLine($"Имя сотруднка {empl.Name}, возраст сотрудника {empl.Age}");
        }

        break;

    case "POST":
        Console.WriteLine("Введите имя сатрудника");
        var name=Console.ReadLine();
        Console.WriteLine("Введите возраст сатрудника");
        var age=Console.ReadLine();

        var employee=new Employee { Name=name,Age=Convert.ToInt32(age)};

        await httpClient.PostAsJsonAsync(connection, employee);
        break;




}












