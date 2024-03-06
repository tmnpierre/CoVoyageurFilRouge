using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.Data;
using CoVoyageur.API.Repositories.Implementations;
using CoVoyageur.API.Repositories.Interfaces;
using CoVoyageur.Core.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FilRougeRefaitContext") ?? throw new InvalidOperationException("Connection string 'FilRougeRefaitContext' not found.")));

builder.Services.AddScoped<IRepository<Feedback>, FeedbackRepository>();
builder.Services.AddScoped<IRepository<Reservation>, ReservationRepository>();
builder.Services.AddScoped<IRepository<Ride>, RideRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
