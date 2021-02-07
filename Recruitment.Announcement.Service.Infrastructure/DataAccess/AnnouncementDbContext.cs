using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Recruitment.Announcement.Service.Domain;
using Recruitment.Announcement.Service.Infrastructure.Domain;

namespace Recruitment.Announcement.Service.Infrastructure.DataAccess
{
    public class AnnouncementDbContext : DbContext
    {
        public DbSet<Service.Domain.Announcement> Announcements { get; set; }
        public AnnouncementDbContext(DbContextOptions<AnnouncementDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnnouncementEntityTypeConfiguration).Assembly);
        }
    }
}
