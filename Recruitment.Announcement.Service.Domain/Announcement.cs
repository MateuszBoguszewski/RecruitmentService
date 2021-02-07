using System;

namespace Recruitment.Announcement.Service.Domain
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public int UserId { get; set; }

        public Announcement(Guid id, string title, string content, DateTime publicationDate, int userId)
        {
            if (title.Length > 100)
                throw new ArgumentException("The title cannot exceed 100 characters.");

            if (content.Length > 1000)
                throw new ArgumentException("The content cannot exceed 1000 characters.");

            if (publicationDate > DateTime.Now.AddDays(30))
                throw new ArgumentException("The date of publication cannot be over 30 later thane date of create.");

            if (publicationDate < DateTime.Now)
                throw new ArgumentException("The date of publication cannot be earlier date of create.");
            Id = id;
            Title = title;
            Content = content;
            CreatedDate = DateTime.Now;
            PublicationDate = publicationDate;
            UserId = userId;
        }
    }
}
