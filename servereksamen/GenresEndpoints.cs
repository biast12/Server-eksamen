using Microsoft.EntityFrameworkCore;
using servereksamen;

public static class GenresEndpoints
{
    public static void MapGenresEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/genres", async (LibraryContext db) => {
            var allData = await db.Set<Genres>().ToListAsync();
            return Results.Ok(allData);
        });

        routes.MapGet("/genres/{id}", async (int id, LibraryContext db) => {
            var data = await db.Set<Genres>().FindAsync(id);
            if (data == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(data);
        });

        routes.MapPost("/genres", async (Genres genres, LibraryContext db) =>
        {
            await db.Set<Genres>().AddAsync(genres);
            await db.SaveChangesAsync();
            return Results.Created($"/genres/{genres.ID}", genres);
        });

        routes.MapPut("/genres/{id}", async (int id, Genres inputMember, LibraryContext db) =>
        {
            var genres = await db.Set<Genres>().FindAsync(id);
            if (genres == null)
            {
                return Results.NotFound();
            }
            genres.Name = inputMember.Name;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        routes.MapDelete("/genres/{id}", async (int id, LibraryContext db) =>
        {
            var genres = await db.Set<Genres>().FindAsync(id);
            if (genres != null)
            {
                db.Set<Genres>().Remove(genres);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}
