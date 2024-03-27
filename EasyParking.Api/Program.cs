using EasyParking.Api.Data;
using EasyParking.Api.Services.UserService;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EasyParkingContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EasyParkingConnection"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAutentication, AuthenticacionService>();



var app = builder.Build();

using(var scope= app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EasyParkingContext>();
    dataContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
