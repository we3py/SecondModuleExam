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
    }
}
