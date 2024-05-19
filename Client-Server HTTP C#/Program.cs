using Client_Server_HTTP_C_.Client;
using Client_Server_HTTP_C_.HTTPRequest;
using Entities.Entities;
using System.Text.RegularExpressions;

var url = "http://127.0.0.1:8888";
var employeeClient=new EmployeeClient(url);

while (true)
{
    Console.WriteLine("Введите тип запроса:");
    string requestMethod = Console.ReadLine();
    var regex = new Regex(@"^[A-Z]+$");
    if (!regex.Match(requestMethod).Success) Console.WriteLine("Тип запроса, должен быть в верхнем регистре. ");

    switch (requestMethod)
    {
        case "GET":
            var employees = employeeClient.GetAll<List<Employee>>();
            foreach (var empl in employees)
            {
                Console.WriteLine($"Id сотруднка {empl.Id}, Имя сотруднка {empl.Name}, возраст сотрудника {empl.Age}");
            }
            break;

        case "POST":
            var post = new PostRequest(employeeClient);
            post.Request();
            break;

        case "PUT":
            var put = new PutRequest(employeeClient);
            put.Request();
            break;

        case "DELETE":
            var delete = new DeleteRequest(employeeClient);
            delete.Request();
            break;
    }
}












