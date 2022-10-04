using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using RestaurantAPI.Data;
namespace RestaurantAPI;

public static class ItemEndpoints
{
    public static void MapItemEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Item", async (RestaurantAPIContext db) =>
        {
            return await db.Item.ToListAsync();
        })
        .WithName("GetAllItems")
        .Produces<List<Item>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Item/{id}", async (int Id, RestaurantAPIContext db) =>
        {
            return await db.Item.FindAsync(Id)
                is Item model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetItemById")
        .Produces<Item>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Item/{id}", async (int Id, Item item, RestaurantAPIContext db) =>
        {
            var foundModel = await db.Item.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateItem")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Item/", async (Item item, RestaurantAPIContext db) =>
        {
            db.Item.Add(item);
            await db.SaveChangesAsync();
            return Results.Created($"/Items/{item.Id}", item);
        })
        .WithName("CreateItem")
        .Produces<Item>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Item/{id}", async (int Id, RestaurantAPIContext db) =>
        {
            if (await db.Item.FindAsync(Id) is Item item)
            {
                db.Item.Remove(item);
                await db.SaveChangesAsync();
                return Results.Ok(item);
            }

            return Results.NotFound();
        })
        .WithName("DeleteItem")
        .Produces<Item>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
