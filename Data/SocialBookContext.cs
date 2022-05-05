#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialBook.Models;

namespace SocialBook.Data
{
    public class SocialBookContext : DbContext
    {
        public SocialBookContext (DbContextOptions<SocialBookContext> options)
            : base(options)
        {
        }

        public DbSet<SocialBook.Models.Profile> Profile { get; set; }

        public DbSet<SocialBook.Models.Post> Post { get; set; }
    }
}
