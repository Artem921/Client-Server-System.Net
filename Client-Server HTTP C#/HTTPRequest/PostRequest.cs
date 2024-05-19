using Client_Server_HTTP_C_.Client;
using Client_Server_HTTP_C_.HTTPRequest.Abstract;
using Entities.Entities;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Client_Server_HTTP_C_.HTTPRequest
{
    public class PostRequest : RequestAbstract
    {
        public PostRequest(EmployeeClient client) : base(client)
        {
        }

        public override Employee CreateEmployee()
        {
            Console.WriteLine("Введите id сатрудника");
            var idEmployee = Console.ReadLine();
            var regex = new Regex("^[0-9 ]+$");
            if (!regex.Match(idEmployee).Success)
            {
                Console.WriteLine("Id сотрудника может иметь только десятичные цифры. ");
                return new ();
            }

            Console.WriteLine("Введите имя сатрудника");
            var name = Console.ReadLine();
            Console.WriteLine("Введите возраст сатрудника");
            var age = Console.ReadLine();

            return new Employee
            {
                Id = Convert.ToInt32(idEmployee),
                Name = name,
                Age = Convert.ToInt32(age)
            };
        }

        public override void Request(Employee employee) => client.Post(new Employee { Id = employee.Id, Name = employee.Name, Age = employee.Age });
    }
}
