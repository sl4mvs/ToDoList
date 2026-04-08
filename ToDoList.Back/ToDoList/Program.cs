using Microsoft.EntityFrameworkCore;
using ToDoList.Persistence;
using ToDoList.Persistence.GraphQL;
using ToDoList.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<TodoQueries>()
    .AddMutationType<TodoMutations>();

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddControllers();


var app = builder.Build();

app.MapGraphQL();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
db.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.MapControllers();

app.Run();