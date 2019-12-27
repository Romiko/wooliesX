using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WooliesX.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {

        private readonly ILogger<SortController> _logger;

        public SortController(ILogger<SortController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            //ToDo Excercise 2
            return null;
        }
    }
}
