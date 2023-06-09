using Grpc.Core;
using IMG;
using Microsoft.EntityFrameworkCore;
using TACOSImagenesAPI.Modelos;
using TACOSImagenesAPI.Servicios;


const int Port = 7252;

Grpc.Core.Server? server = null;
try
{
    server = new Grpc.Core.Server()
    {
        Services = {
            ImagenesService.BindService(new ImegenesServiceImp()),
        },
        Ports = { new ServerPort("localhost", Port,
                    ServerCredentials.Insecure) }
    };
    server.Start();
    Console.WriteLine("Servidor C# escuchando en el puerto: " + Port);
    Console.ReadKey();
}
catch (IOException e)
{
    Console.WriteLine("The server failed to start : " + e.Message);
    throw;
}
finally
{
    if (server != null)
    {
        server.ShutdownAsync().Wait();
    }
}