using Lab2;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdvertismentDb>(opt => opt.UseInMemoryDatabase("AdvertismentList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/advetisments", async (AdvertismentDb db) => 
    await db.Advertisments.ToListAsync());

app.MapPost("/advetisments", async (Advertisment advertisments, AdvertismentDb db) =>
{
    db.Advertisments.Add(advertisments);
    await db.SaveChangesAsync();

    return Results.Created($"/advertisments/{advertisments.SellerID}", advertisments);
});

app.Run();
