using MediatR;
using RecruitmentService.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Recruitment.Announcement.Service.Domain;

namespace Recruitment.Announcement.Service.Application.Commands.AddAnnouncement
{
    public class AddAnnouncementCommandHandler : ICommandHandler<AddAnnouncementCommand>
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AddAnnouncementCommandHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }
        public async Task<Unit> Handle(AddAnnouncementCommand request, CancellationToken cancellationToken)
        {          
            if (_announcementRepository.CountAllByDate(request.PublicationDate, request.UserId).Result >= 5)
                throw new ArgumentException("The number of the same publication date cannot be over than 5.");

            var announcement = new Domain.Announcement(request.Id, request.Title, request.Content, request.PublicationDate, request.UserId);

            await _announcementRepository.AddAsync(announcement);
            await _announcementRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
