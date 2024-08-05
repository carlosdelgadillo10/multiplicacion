using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8003); // Configurar la aplicación para escuchar en el puerto 8003
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Endpoint POST para multiplicar dos números
app.MapPost("/multiply", (MultiplyRequest request) =>
{
    return request.num1 * request.num2
});

app.Run();

// Definir el modelo de solicitud fuera del método Main
public class MultiplyRequest
{
    public int num1 { get; set; }
    public int num2 { get; set; }
}
