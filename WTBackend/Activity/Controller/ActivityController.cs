using Microsoft.AspNetCore.Mvc;
using WTBackend.Activity.InterfaceActivity;
using WTBackend.Activity.Models;

namespace WTBackend.Activity.ActivityController
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepo _ActivityRepo;
        public ActivityController(IActivityRepo activityRepository) { 
            _ActivityRepo = activityRepository;
        }

        [HttpGet("/activities")]
        public async Task<ActionResult<List<ActivityModel>>> GetAllActivities()
        {
            var result = await _ActivityRepo.GetAllActivities();
            if (result != null && result.Any())
            {
                return Ok(result);
            }
            return NotFound("No activities found.");
        }
    }
}
