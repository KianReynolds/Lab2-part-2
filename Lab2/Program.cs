using AdvertismentApi.Data;
using AdvertismentApi.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdvertismentDb>(opt => opt.UseInMemoryDatabase("AdvertismentList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

//var getAds = app.MapGroup("/advertisments");

app.MapGet("/advertisment", async (AdvertismentDb db) =>
{
return await db.Advertisments
    .Include(a => a.Seller)
        .Include(a => a.Category)
        .ToListAsync();
});

app.MapGet("/advertisment/{id}", async (int id, AdvertismentDb db) =>
{
    var advertisment = await db.Advertisments
    .Include(a => a.Seller)
    .Include(a => a.Category)
    .FirstOrDefaultAsync(a => a.Id == Id);
    return advertisment is not null ? Results.Ok(advertisment) : Results.NotFound();
});

app.MapPost("/advertisment", async (Advertisment ad, AdvertismentDb db) =>
{
    db.Advertisments.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/advertisments/{ad.Id}", ad);
});

app.MapPut("/advertisment/{id}", async (int id, Advertisment ad, AdvertismentDb db) =>
{
    var advertisment = await db.Advertisments.FindAsync(id);
    if (advertisment is null) return Results.NotFound();

    advertisment.Description = ad.Description;
    advertisment.Category = ad.Category;
    advertisment.Price = ad.Price;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/advertisment/{id}", async (int id, AdvertismentDb db) =>
{
    if(await db.Advertisments.FindAsync(id) is Advertisment advertisment)
    {
        db.Advertisments.Remove(advertisment);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.MapGet("/sellers", async (AdvertismentDb db) =>
    await db.Advertisments.ToListAsync());

app.MapGet("/categories", async (AdvertismentDb db) => 
    await db.Advertisments.ToListAsync());

app.Run();
