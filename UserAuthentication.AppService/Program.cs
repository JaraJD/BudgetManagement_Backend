using AutoMapper.Data;
using UserAuthentication.DrivenAdapter.Interfaces;
using UserAuthentication.DrivenAdapter;
using UserAuthentication.AppService.Mapping;
using UserAuthentication.UseCase.Gateway;
using UserAuthentication.UseCase.UseCase;
using UserAuthentication.UseCase.Gateway.Repository;
using UserAuthentication.DrivenAdapter.Repositories;
using UserAuthentication.AppService.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));
builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("DefaultConnection"), "User_Authentication"));

builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IBalanceUseCase, BalanceUseCase>();
builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllers();

app.Run();
