using CurlingChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurlingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurlingController :ControllerBase
    {
        private readonly ICurlingService _curlingService;
        private readonly ILogger<CurlingController> _logger;

        public CurlingController(ICurlingService curlingService, ILogger<CurlingController> logger)
        {
            _curlingService = curlingService;
            _logger = logger;
        }

        [HttpPost(Name = "Start")]
        public IActionResult StartCurling(int n, int r)
        {
            var plane = _curlingService.Start(n, r);
            return new OkObjectResult(plane.GetAllYCoordinates());
        }
    }
}