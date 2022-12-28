using CurlingChallenge.Models;
using CurlingChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        public IActionResult StartCurling(int discNumber, int radius)
        {
            if (discNumber < 1)
            {
                throw new ArgumentOutOfRangeException("Disc number should be more then 1");
            }

            if (radius > 1000)
            {
                throw new ArgumentOutOfRangeException("Radius should be less then 1000");
            }

            _curlingService.Start(discNumber, radius, out Plane plane);
            return new OkObjectResult(plane.GetCoordinates());
        }
    }
}