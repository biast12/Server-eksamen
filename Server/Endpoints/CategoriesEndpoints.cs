using Microsoft.EntityFrameworkCore;

public static class CategoriesEndpoints
{
    public static void MapCategoriesEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/categories", async (LibraryContext db) => {
            var allData = await db.Set<Categories>().ToListAsync();
            return Results.Ok(allData);
        });

        routes.MapGet("/categories/{id}", async (int id, LibraryContext db) => {
            var data = await db.Set<Categories>().FindAsync(id);
            if (data == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(data);
        });

        routes.MapPost("/categories", async (Categories categories, LibraryContext db) =>
        {
            await db.Set<Categories>().AddAsync(categories);
            await db.SaveChangesAsync();
            return Results.Created($"/categories/{categories.ID}", categories);
        });

        routes.MapPut("/categories/{id}", async (int id, Categories inputMember, LibraryContext db) =>
        {
            var categories = await db.Set<Categories>().FindAsync(id);
            if (categories == null)
            {
                return Results.NotFound();
            }
            categories.Name = inputMember.Name;
            categories.Icon = inputMember.Icon;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        routes.MapDelete("/categories/{id}", async (int id, LibraryContext db) =>
        {
            var categories = await db.Set<Categories>().FindAsync(id);
            if (categories != null)
            {
                db.Set<Categories>().Remove(categories);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}
