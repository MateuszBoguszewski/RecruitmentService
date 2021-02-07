using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Announcement.Service.Domain
{
    public interface IAnnouncementRepository
    {
        Task SaveChangesAsync();
        Task AddAsync(Announcement announcement);
        Task<int> CountAllByDate(DateTime publicationDate, int userId);
    }
}
