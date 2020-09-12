using System;
using APISafra.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISafra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorningCallsController : ControllerBase
    {
        private ISafraMorningCallsService SafraMorningCallsService;

        public MorningCallsController(ISafraMorningCallsService SafraMorningCallsService)
        {
            this.SafraMorningCallsService = SafraMorningCallsService;
        }


        // GET api/morningcalls
        [HttpGet("")]
        public IActionResult GetMorningCalls(string id)
        {
            return Ok(SafraMorningCallsService.getMorningCalls());
        }
    }
}