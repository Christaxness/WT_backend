using Microsoft.AspNetCore.Mvc;
using WTBackend.Column.Dto;
using WTBackend.Column.Interface;

namespace WTBackend.Column.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnRepo _columnRepo;

        public ColumnController(IColumnRepo columnRepo)
        {
            _columnRepo = columnRepo;
        }

        [HttpGet("/columns")]
        public async Task<ActionResult<List<ResponseColumnDTO>>> GetAllColumns()
        {
            var result = await _columnRepo.GetAllColumns();
            if (result != null && result.Any())
            {
                return Ok(result);
            }
            return NotFound("No activities found.");
        }

        [HttpPost("/columns")]
        public async Task<ActionResult> CreateColumn(CreateColumnDTO createColumnDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _columnRepo.CreateColumn(createColumnDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("/columns")]
        public async Task<ActionResult> DeleteColumn(string title) {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _columnRepo.DeleteColumn(title);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
