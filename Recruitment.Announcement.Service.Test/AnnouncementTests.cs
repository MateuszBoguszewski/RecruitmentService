using NUnit.Framework;
using System;
using Recruitment.Announcement.Service.Controllers;
using MediatR;

namespace Recruitment.Announcement.Service.Test
{
    public class AnnouncementTests
    {
        [Test]
        public void CheckMaxLengthOfTitle()
        {
            var annoncement = new Domain.Announcement(Guid.NewGuid(), "Title", "Content", DateTime.Now.AddDays(5), 1);
            Assert.IsTrue(annoncement.Title.Length <= 100);
        }

        [Test]
        public void CheckOverMaxLengthOfTitle()
        {                      
            Assert.Throws<ArgumentException>(() =>
            {
                new Domain.Announcement(Guid.NewGuid(), "TitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitle", "Content", DateTime.Now, 1);
            });
        }
        [Test]
        public void CheckNullTitle()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                new Domain.Announcement(Guid.NewGuid(), null, "Content", DateTime.Now, 1);
            });
        }

        [Test]
        public void CheckNullContent()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                new Domain.Announcement(Guid.NewGuid(), "Title", null, DateTime.Now.AddDays(5), 1);
            });
        }

        [Test]
        public void CheckMaxLengthOfContent()
        {
            var annoncement = new Domain.Announcement(Guid.NewGuid(), "Title", "Content", DateTime.Now.AddDays(5), 1);
            Assert.IsTrue(annoncement.Content.Length <= 1000);
        }

        [Test]
        public void CheckMaxPublicationDate()
        {
            var annoncement = new Domain.Announcement(Guid.NewGuid(), "Title", "Content", DateTime.Now.AddDays(5), 1);
            Assert.IsTrue(annoncement.PublicationDate <= annoncement.CreatedDate.AddDays(30));
        }
        
        [Test]
        public void CheckOverMaxPublicationDate()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Domain.Announcement(Guid.NewGuid(), "Title", "Content", DateTime.Now.AddDays(35), 1);
            });
        }

        [Test]
        public void CheckWrongPublicationDate()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Domain.Announcement(Guid.NewGuid(), "Title", "Content", DateTime.Now.AddDays(-5), 1);
            });
        }
    }
}