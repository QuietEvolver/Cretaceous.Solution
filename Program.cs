using CretaceousApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// delete above line & replace ...
// To Be Used w VIEWS: 
// builder.Services.AddControllersWithViews();


//Updating Program.cs to Use MySQL and the CretaceousApiContext
builder.Services.AddDbContext<CretaceousApiContext>(
                    DbContextOptions => DbContextOptions
                    .UseMySql(
                        builder.Configuration["ConnectionStrings:DefaultConnection"],
                        ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                        )
                    )
);


//      an implementation of Swagger documentation:
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();
    // To serve the Swagger UI at the app's root (https://localhost:<port>/), set the RoutePrefix property to an empty string
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); 
        options.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
