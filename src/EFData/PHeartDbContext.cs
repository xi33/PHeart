using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Models;
using Domain.Models.Authentication;

namespace EFData
{
    class PHeartDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<FstClass> FstClasses { get; set; }
        public DbSet<SndClass> SndClasses { get; set; }
        public DbSet<News> Newses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
    }
}
