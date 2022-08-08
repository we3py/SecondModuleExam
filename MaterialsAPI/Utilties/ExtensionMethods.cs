using MaterialsAPI.Services;

namespace MaterialsAPI.Utilties
{
    public static class ExtensionMethods
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IMaterialReviewRepository, MaterialReviewRepository>();
            services.AddScoped<IMaterialsRepository, MaterialsRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<EducationMaterialService>();
        }
    }
}
