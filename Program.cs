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
    int result = request.Num1 * request.Num2;
    return Results.Ok(new { result = result });
});

app.Run();

// Definir el modelo de solicitud fuera del método Main
public class MultiplyRequest
{
    public int Num1 { get; set; }
    public int Num2 { get; set; }
}
