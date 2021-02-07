using Recruitment.Announcement.Service.Application.Commands.AddAnnouncement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruitment.Announcement.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnnouncementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddAnnouncement([FromBody]  AnnouncementStateRepresentation announcementStateRepresentation)
        {
            var result = await _mediator.Send(new AddAnnouncementCommand(Guid.NewGuid(), announcementStateRepresentation.Title, announcementStateRepresentation.Content, announcementStateRepresentation.PublicationDate, announcementStateRepresentation.UserId));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public void UpdateAnnouncement(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteAnnouncement(int id)
        {
        }
    }
}
