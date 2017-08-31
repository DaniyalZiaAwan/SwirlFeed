using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SwirlFeed.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Posts)
                .WithRequired(p => p.Posted_By);

            modelBuilder.Entity<Friend>().HasRequired(f => f.User2)
                .WithMany(u => u.Friends).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}