using Microsoft.EntityFrameworkCore;
using XmlToJsonAPI.DAL.Entity;

namespace XmlToJsonAPI.DAL.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<XmlTemplate>()
                .ToTable("xmlTbl");
        }
        public DbSet<XmlTemplate> XmlTemplates { get; set; } = null!;
    }
}
