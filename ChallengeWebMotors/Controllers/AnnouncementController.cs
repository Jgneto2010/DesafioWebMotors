using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service.ViewModels.Announcements;
using System.Threading.Tasks;

namespace ChallengeWebMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

       
        [HttpPost]
        public async Task<IActionResult> RegisterAnnouncement([FromBody] AddAnnouncementViewModel input)
        {
            if (input == null)
            {
                return BadRequest();
            }

            var obj = await _announcementsService.RegisterAd(input);

            if (obj)
            return Ok(obj);
            
            return BadRequest();

        }

        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAnnouncement([FromRoute] int id)
        {
            var obj = await _announcementsService.Remove(id);
            return Ok(obj);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAnnouncement([FromRoute] int id)
        {
            var _event = await _announcementsService.GetByIdObj(id);
            return Ok(_event);
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] UpDateAnnouncementViewModel upDateAnnouncementViewModel)
        {
            if (upDateAnnouncementViewModel == null)
            {
                return BadRequest();
            }
            await _announcementsService.Update(upDateAnnouncementViewModel);
            return Ok();
        }
    }
}
