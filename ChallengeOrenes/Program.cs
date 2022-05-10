using ChallengeOrenes.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ChallengeOrenes.Services;
using ChallengeOrenes.Repositories;
using ChallengeOrenes.Repositories.RepositoryImpl;
using ChallengeOrenes.Services.ServiceImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer());

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ILocationRepositoy, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurar el Automapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ProfileMapper());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

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
