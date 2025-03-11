using Microsoft.EntityFrameworkCore;
using servereksamen;

public static class BooksEndpoints
{
    public static void MapBooksEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/books", async (LibraryContext db) => {
            var allData = await db.Set<Books>().ToListAsync();
            return Results.Ok(allData);
        });

        routes.MapGet("/books/{id}", async (int id, LibraryContext db) => {
            var data = await db.Set<Books>().FindAsync(id);
            if (data == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(data);
        });

        routes.MapPost("/books", async (Books books, LibraryContext db) =>
        {
            await db.Set<Books>().AddAsync(books);
            await db.SaveChangesAsync();
            return Results.Created($"/books/{books.ID}", books);
        });

        routes.MapPut("/books/{id}", async (int id, Books inputMember, LibraryContext db) =>
        {
            var books = await db.Set<Books>().FindAsync(id);
            if (books == null)
            {
                return Results.NotFound();
            }
            books.Title = inputMember.Title;
            books.Description = inputMember.Description;
            books.GenreID = inputMember.GenreID;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        routes.MapDelete("/books/{id}", async (int id, LibraryContext db) =>
        {
            var books = await db.Set<Books>().FindAsync(id);
            if (books != null)
            {
                db.Set<Books>().Remove(books);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}