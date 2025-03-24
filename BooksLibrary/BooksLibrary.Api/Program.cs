using BooksLibrary.Api;
using BooksLibrary.Application;
using BooksLibrary.Application.Behaviour;
using BooksLibrary.Application.Shared.Abstractions;
using BooksLibrary.Infrastructure;
using BooksLibrary.Infrastructure.Persistance.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConfigurations();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers((options) =>
{
    options.Filters.Add<ValidationFilterBehavior>();
});
builder.Services.AddProblemDetails();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IAppDbContext>();
    DbSeeder.SeedData(context); 
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.MapControllers();
app.Run();