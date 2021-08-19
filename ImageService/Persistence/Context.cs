using ImageServiceApi.Models;
using ImageServiceApi.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ImageServiceApi.Persistence
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ImageData> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }


    }
}
