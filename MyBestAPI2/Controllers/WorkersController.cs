// Controllers/WorkersController.cs
using Microsoft.AspNetCore.Mvc;
using MyBestAPI2.Services;
using System.Threading.Tasks;

namespace MyBestAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] decimal? maxSalary)
        {
            var workers = await _workerService.GetWorkersAsync(maxSalary);
            return Ok(workers);
        }
    }


}
