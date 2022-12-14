var builder = WebApplication.CreateBuilder(args);

var mapConfig = new MapperConfiguration(c =>
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
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<MaterialsContext>(builder.Configuration["ConnectionStrings:MaterialsDB"]);
builder.Services.AddSqlServer<UserContext>(builder.Configuration["ConnectionStrings:UsersDB"]);
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
builder.Services.AddScoped<LoggingMiddleware>();
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
