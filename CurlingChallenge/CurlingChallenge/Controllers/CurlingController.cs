using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurlingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurlingController :ControllerBase
    {
        private readonly ICurlingService _curlingService;

        public CurlingController(ICurlingService curlingService)
        {
            _curlingService = curlingService;
        }

        [HttpPost(Name = "Start")]
        public IActionResult StartCurling(int numberOfDiscs, int radius)
        {
            _curlingService.Start(numberOfDiscs, radius, out Plane plane);
            return new OkObjectResult(plane.GetCoordinates());
        }
    }
}