namespace MaterialsAPI.Data.Context
{
    public class MaterialsContext : DbContext
    {
        public MaterialsContext(DbContextOptions<MaterialsContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialReview> MaterialReviews { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Material>().HasKey(m => m.Id);
            modelBuilder.Entity<MaterialReview>().HasKey(mr => mr.Id);
            modelBuilder.Entity<MaterialType>().HasKey(mt => mt.Id);

            modelBuilder.Entity<Material>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Material);

            modelBuilder.Entity<Material>()
                .HasOne(m => m.Author)
                .WithMany(a => a.Materials);
        }

    }
}
