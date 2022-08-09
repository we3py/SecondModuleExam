using MaterialsAPI.Data.DAL.Interfaces;
using MaterialsAPI.MapperProfiles;
using MaterialsAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var mapConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AddProfile(new AuthorProfile());
    c.AddProfile(new MaterialProfile());
    c.AddProfile(new MaterialReviewProfile());
    c.AddProfile(new MaterialTypeProfile());
    c.AddProfile(new UserProfile());
});
var mapper = mapConfig.CreateMapper();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<MaterialsContext>(builder.Configuration.GetConnectionString("MaterialsDB"));
builder.Services.AddSqlServer<UserContext>(builder.Configuration.GetConnectionString("UsersDB"));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(build =>
    {
        build.AllowAnyOrigin();
    });
});
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.BuildSwagger();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
