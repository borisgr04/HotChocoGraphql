using ApiGq;
using GraphApi;
using HotG;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CibContext>(
    opt => opt.UseInMemoryDatabase("Demo"));

// Add services to the container.

builder.Services
    .AddSingleton<Repository>()
    .AddSingleton<CryptService>()
    .AddGraphQLServer()
    .RegisterDbContext<CibContext>()
    .AddQueryType<Query>()
    .AddFiltering();

var app = builder.Build();

var cibContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<CibContext>();
await DatabaseSeeder.SeedAsync(cibContext);

// Configure the HTTP request pipeline.


app.MapGraphQL();

app.Run();
