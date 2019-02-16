using Mess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mess.Persistence
{
    public class MessDbContext:IdentityDbContext<ApplicationUser>
    {
        // public DbSet<ApplicationUser> smUsers { get; set; }
        public DbSet<SmartMess> smMesses { get; set; }
        public MessDbContext(DbContextOptions<MessDbContext> options)
        :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<SmartMess>().HasKey(mess=>mess.MessId);
            modelBuilder.Entity<SmartUser>().HasKey(user=>user.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}