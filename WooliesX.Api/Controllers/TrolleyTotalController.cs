using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesX.Infrastructure.ApiClient;

namespace WooliesX.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrolleyTotalController : ControllerBase
    {
        private readonly ILogger<TrolleyTotalController> _logger;
        private readonly IConfiguration _config;
        private Client _client;

        public TrolleyTotalController(ILogger<TrolleyTotalController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _client = new Client(new HttpClient());
            _client.BaseUrl = _config.GetValue<string>("WooliesXBaseUrl");
        }

        [HttpPost]
        public async Task<double> Post(Trolley trolley)
        {
            return await _client.ApiResourceTrolleyCalculatorPostAsync(_config.GetValue<Guid>("ApiToken"), trolley);
        }
    }
}
