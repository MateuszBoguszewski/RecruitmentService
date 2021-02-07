using System;
using System.Collections.Generic;
using System.Text;
using RecruitmentService.Common;

namespace Recruitment.Announcement.Service.Application.Commands.AddAnnouncement
{
    public class AddAnnouncementCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public int UserId { get; set; }

        public AddAnnouncementCommand(Guid id, string title, string content, DateTime publicationDate, int userId)
        {
            Id = id;
            Title = title;
            Content = content;
            PublicationDate = publicationDate;
            UserId = userId;
        }
    }
}
