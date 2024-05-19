using Client_Server_HTTP_C_.Client;
using Client_Server_HTTP_C_.HTTPRequest.Abstract;
using Entities.Entities;

namespace Client_Server_HTTP_C_.HTTPRequest
{
    public class PutRequest : RequestAbstract
    {
        public PutRequest(EmployeeClient client) : base(client)
        {
        }

        public override Employee CreateEmployee()
        {
            Console.WriteLine("Введите Id сатрудника");
            var id = Console.ReadLine();

            var employee = client.Get<Employee>(id);

            if (employee is null)
            {
                Console.WriteLine("Сотрудник с таким id не найден!");
                return new Employee();
            }

            else
            {
                Console.WriteLine("Введите имя сатрудника");
                var nameUpdate = Console.ReadLine();
                Console.WriteLine("Введите возраст сатрудника");
                var ageUpdate = Console.ReadLine();

                employee.Name = nameUpdate;

                employee.Age = Convert.ToInt32(ageUpdate);

                return employee;
            }
        }

        public override void Request(Employee employee)=> client.Put<Employee>(employee);
    }
}
