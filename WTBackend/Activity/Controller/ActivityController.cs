using Microsoft.AspNetCore.Mvc;
using WTBackend.Activity.Dto;
using WTBackend.Activity.InterfaceActivity;

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

        [HttpPost("/activities")]
        public async Task<ActionResult> CreateActivity(CreateActivityDTO activityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _ActivityRepo.CreateActivityAsync(activityModel);
            if (result.Success)
            {
                return Created();
            }
            return BadRequest(result);
        }
    }
}
