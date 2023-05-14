using Microsoft.EntityFrameworkCore;
using SameZeraIjedynka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFavorite>().HasKey(x => new {x.EventId, x.UserId});
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Entities.Event> Events { get; set; }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.UserFavorite> Favorites { get; set; }
    }

}
