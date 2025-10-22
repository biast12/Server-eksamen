using Microsoft.EntityFrameworkCore;

public static class ItemsEndpoints
{
    public static void MapItemsEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/items", async (LibraryContext db) => {
            var allData = await db.Set<Items>().ToListAsync();
            return Results.Ok(allData);
        });

        routes.MapGet("/items/{id}", async (int id, LibraryContext db) => {
            var data = await db.Set<Items>().FindAsync(id);
            if (data == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(data);
        });

        routes.MapGet("/items/category/{categoryID}/genre/{genreID}", async (int categoryID, int genreID, LibraryContext db) => {
            var data = await db.Set<Items>().Where(i => i.CategoryID == categoryID.ToString() && i.GenreID == genreID).ToListAsync();
            if (data == null || !data.Any())
            {
                return Results.Ok(new[] { new { } });
            }
            return Results.Ok(data);
        });

        routes.MapPost("/items", async (Items items, LibraryContext db) =>
        {
            await db.Set<Items>().AddAsync(items);
            await db.SaveChangesAsync();
            return Results.Created($"/items/{items.ID}", items);
        });

        routes.MapPut("/items/{id}", async (int id, Items inputItem, LibraryContext db) =>
        {
            var item = await db.Set<Items>().FindAsync(id);
            if (item == null)
            {
                return Results.NotFound();
            }
            item.Title = inputItem.Title;
            item.Description = inputItem.Description;
            item.GenreID = inputItem.GenreID;
            item.CategoryID = inputItem.CategoryID;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        routes.MapDelete("/items/{id}", async (int id, LibraryContext db) =>
        {
            var item = await db.Set<Items>().FindAsync(id);
            if (item != null)
            {
                db.Set<Items>().Remove(item);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}
