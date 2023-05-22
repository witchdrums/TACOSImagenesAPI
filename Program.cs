namespace TACOSImagenesAPI;

using Microsoft.EntityFrameworkCore;
using TACOSImagenesAPI.Negocio;
using TACOSImagenesAPI.Modelos;
using Grpc.Core;
using Saludo;
using TACOSImagenesAPI.Servicios;

/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IImagenMgt, ImagenMgr>();
builder.Services.AddDbContext<TacosimagenesContext>(options =>
                options.UseMySql(
                    "server=localhost;database=tacosdb;uid=tacosUser;pwd=T4C05",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"
                )));

var app = builder.Build();
*/



    class Program

    {

        const int Port = 7252;



        static void Main(string[] args)

        {

            Grpc.Core.Server server = null;
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

                    server.ShutdownAsync().Wait();

            }

        }

    }



/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/