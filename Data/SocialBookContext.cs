#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialBook.Models;

namespace SocialBook.Data
{
    public class SocialBookContext : IdentityDbContext<IdentityUser>
    {
        public SocialBookContext (DbContextOptions<SocialBookContext> options)
            : base(options)
        {
        }

        public DbSet<SocialBook.Models.Profile> Profile { get; set; }

        public DbSet<SocialBook.Models.Post> Post { get; set; }

        public DbSet<SocialBook.Models.Comment> Comment { get; set; }

        public DbSet<SocialBook.Models.Reaction> Reaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().ToTable("Profile");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Reaction>().ToTable("Reaction");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            base.OnModelCreating(modelBuilder);
        }
    }
}
