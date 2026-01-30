using ApiChatOnline.Controllers.Validations;
using ApiChatOnline.Data;
using ApiChatOnline.Extensions;
using ApiChatOnline.Repository;
using ApiChatOnline.Repository.IRepository;
using ApiChatOnline.Services;
using ApiChatOnline.Services.IServices;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MongoDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb");
    var databaseName = builder.Configuration["MongoDB:DatabaseName"];
    options.UseMongoDB(connectionString!, databaseName!);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IEncryptService, EncryptService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidation>();
builder.Services.AddFluentValidationAutoValidation();
var config = TypeAdapterConfig.GlobalSettings;
builder.Services.AddSingleton(config);

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapScalarApiReference();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
