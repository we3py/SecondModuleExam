using MaterialsAPI.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

var mapConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AddProfile(new AuthorProfile());
    c.AddProfile(new MaterialProfile());
    c.AddProfile(new MaterialReviewProfile());
    c.AddProfile(new MaterialTypeProfile());
});
var mapper = mapConfig.CreateMapper();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<MaterialsContext>(builder.Configuration.GetConnectionString("MaterialsDB"));
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
