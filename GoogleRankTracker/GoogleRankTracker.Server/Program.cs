using GoogleRankTracker.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:7013",
                                "https://localhost:5173");
        });
});

builder.Services.AddDbContext<GoogleSearchResultDb>(opt => opt.UseInMemoryDatabase("GoogleSearchResultList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

#region GoogleSearch endpoints group

var endpoints = app.MapGroup("/googlesearch");

endpoints.MapGet("/history", async (GoogleSearchResultDb db) =>
    await db.GoogleSearchResults.ToListAsync());

endpoints.MapGet("/trends", async (GoogleSearchResultDb db) =>
    await db.GoogleSearchResults.Where(t => t.Rankings != "0").OrderBy(x => x.Rankings).Take(5).ToListAsync());

endpoints.MapPost("/{krd}/{url}", async (string krd, string url, GoogleSearchResultDb db) =>
{
        GoogleSearchResult obj = new()
        {
            Keywords = krd,
            Url = url,
            Rankings = GoogleSearchRequest.GetRankings(krd, url),
            Formatteddatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
        };

        db.GoogleSearchResults.Add(obj);
        await db.SaveChangesAsync();

        return obj;
});

#endregion

app.Run();
