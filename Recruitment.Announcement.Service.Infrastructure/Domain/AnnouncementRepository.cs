using Recruitment.Announcement.Service.Domain;
using Recruitment.Announcement.Service.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Announcement.Service.Infrastructure.Domain
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly AnnouncementDbContext _dbContext;

        public AnnouncementRepository(AnnouncementDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(Service.Domain.Announcement announcement)
        {
            await _dbContext.Announcements.AddAsync(announcement);
        }

        public async Task<int> CountAllByDate(DateTime publicationDate, int userId)
        {
            return _dbContext.Announcements.Where(a => a.PublicationDate == publicationDate && a.UserId == userId).Count();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
