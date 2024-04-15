using Server;
using Server.Repository;


var serer = new HttpListenerServices(new EmployeesRepository());
serer.GetContext();

Console.Read();


