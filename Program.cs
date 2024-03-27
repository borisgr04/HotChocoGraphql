using ApiGq;
using GraphApi;
using HotG;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;

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
    .AddAuthorization()
    .AddFiltering();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddMicrosoftIdentityWebApi(builder.Configuration);

var app = builder.Build();

var cibContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<CibContext>();
await DatabaseSeeder.SeedAsync(cibContext);

Injector.Crypt = app.Services.CreateScope().ServiceProvider.GetRequiredService<CryptService>();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

app.Run();
