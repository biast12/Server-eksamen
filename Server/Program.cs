using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5068");

// Register LibraryContext as a service
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

Console.WriteLine("Connected to SQL Server database.");

app.MapGet("/", () => {
    var message = "Server is working";
    return Results.Ok(message);
});

// Use the extension methods to map the endpoints
app.MapItemsEndpoints();
app.MapGenresEndpoints();
app.MapCategoriesEndpoints();

app.Run();