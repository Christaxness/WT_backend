using Microsoft.AspNetCore.Mvc;
using WTBackend.Activity.InterfaceActivity;
using WTBackend.Column.Dto;
using WTBackend.Column.Interface;
using WTBackend.Column.Models;

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
        public async Task<ActionResult<List<ColumnDTO>>> GetAllColumns()
        {
            var result = await _columnRepo.GetAllColumns();
            if (result != null && result.Any())
            {
                return Ok(result);
            }
            return NotFound("No activities found.");
        }
    }
}
