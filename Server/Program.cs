using Server;
using Server.Repository;


var serer = new HttpListenerServices(new ProcessorsRepository());
serer.GetContext();
Console.Read();

