using System.ComponentModel.Composition;
using System.Data.Entity;
using Test.Core.Models;

namespace Test.UserExt.Repositories
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [DbConfigurationType(typeof(NpgSqlConfiguration))]
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base("name=UserContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
