using MaterialsAPI.Data.DAL.Interfaces;
using MaterialsAPI.Services;
using MaterialsAPI.UsersDATA;

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
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<EducationMaterialService>();
            services.AddScoped<LoggingRegisterService>();
        }
    }
}
