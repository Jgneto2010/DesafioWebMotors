using Domain.Entities;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contexts
{
    public class WebMotorsContext : DbContext
    {
        public WebMotorsContext(DbContextOptions<WebMotorsContext> options) : base(options) { }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnnouncementMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
