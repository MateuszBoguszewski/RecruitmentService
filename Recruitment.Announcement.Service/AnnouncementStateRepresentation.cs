using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruitment.Announcement.Service.Domain;

namespace Recruitment.Announcement.Service
{
    public class AnnouncementStateRepresentation
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public int UserId { get; set; }

        public AnnouncementStateRepresentation()
        {
        }

        public AnnouncementStateRepresentation(Domain.Announcement announcement)
        {
            Title = announcement.Title;
            Content = announcement.Content;
            PublicationDate = announcement.PublicationDate;
            UserId = announcement.UserId;
        }
    }
}
