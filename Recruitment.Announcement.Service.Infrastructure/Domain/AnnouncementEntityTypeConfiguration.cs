using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Recruitment.Announcement.Service.Domain;

namespace Recruitment.Announcement.Service.Infrastructure.Domain
{
    internal class AnnouncementEntityTypeConfiguration : IEntityTypeConfiguration<Service.Domain.Announcement>
    {
        public void Configure(EntityTypeBuilder<Service.Domain.Announcement> builder)
        {
            builder.ToTable("Announcement");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(1000);
            builder.Property<DateTime>("CreatedDate").IsRequired();
            builder.Property<DateTime>("PublicationDate").IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
