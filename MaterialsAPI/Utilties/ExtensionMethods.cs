using MaterialsAPI.Data.DAL.Interfaces;
using MaterialsAPI.Services;
using MaterialsAPI.Services.Interfaces;
using MaterialsAPI.UsersDATA;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MaterialsAPI.Utilties
{
    public static class ExtensionMethods
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IMaterialReviewRepository, MaterialReviewRepository>();
            services.AddScoped<IMaterialsRepository, MaterialsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<MaterialType>, Repository<MaterialType>>();

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEducationMaterialService, EducationMaterialService>();
            services.AddScoped<ILoggingRegisterService, LoggingRegisterService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IMaterialTypeService, MaterialTypeService>();
            services.AddScoped<IReviewsService, ReviewsService>();
        }

        public static void BuildSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SecondExamAPI",
                    Description = "web api made for utilize education materials"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                swagger.EnableAnnotations();      
            });
        }
    }
}
