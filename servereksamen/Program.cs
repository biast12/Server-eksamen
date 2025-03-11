using servereksamen;

var builder = WebApplication.CreateBuilder(args);

// Register LibraryContext as a service
builder.Services.AddDbContext<LibraryContext>();

var app = builder.Build();

await using var db = new LibraryContext();
Console.WriteLine($"Database path: {db.DbPath}.");

app.MapGet("/", () => {
    var message = "Server is working";
    return Results.Ok(message);
});

// Use the extension methods to map the endpoints
app.MapBooksEndpoints();
app.MapGenresEndpoints();

app.Run();