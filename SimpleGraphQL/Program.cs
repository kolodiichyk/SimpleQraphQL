using Microsoft.EntityFrameworkCore;
using SimpleGraphQL;
using SimpleGraphQL.Schema;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddEntityFrameworkSqlite()
    .AddDbContext<ProductsDbContext>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", ([Service] ProductsDbContext dbContext) =>
{
    dbContext.Database.Migrate();
    
    var t = dbContext.Products.Include(t=>t.Manufacturer).ToList();
    return "This is sample of implementation of GraphQL";
});
app.MapGraphQL();
app.MapGraphQLSchema();

app.Run();