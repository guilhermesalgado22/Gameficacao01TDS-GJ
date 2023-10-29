using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projetos.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>();


var app = builder.Build();

// Se você quiser criar o banco de dados (caso ainda não exista), pode fazer o seguinte:
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    
    try
    {
        context.Database.EnsureCreated();
        // DbInitializer.Initialize(context); // Descomente se você quiser inicializar o DB
    }
    catch (Exception ex)
    {
        // Aqui você pode logar ou tratar exceções específicas relacionadas à criação do banco de dados
        Console.WriteLine($"An error occurred while creating the database: {ex.Message}");
    }
}

// Middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
