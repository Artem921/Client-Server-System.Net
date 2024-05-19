using Client_Server_HTTP_C_.Client;
using Client_Server_HTTP_C_.HTTPRequest.Abstract;
using Entities.Entities;

namespace Client_Server_HTTP_C_.HTTPRequest
{
    public class DeleteRequest : RequestAbstract
    {
        public DeleteRequest(EmployeeClient client) : base(client)
        {
        }

        public override Employee CreateEmployee()
        {
            Console.WriteLine("Введите Id сатрудника");
            var id = Console.ReadLine();

            var employee = new Employee {Id =Convert.ToInt32(id) };
            
            return employee;
        }

        public override void Request(Employee employee)
        {
            client.Delete(employee.Id);
        }
    }
}
