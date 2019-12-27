using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesX.Infrastructure.ApiClient;

namespace WooliesX.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {

        private readonly ILogger<SortController> _logger;
        private readonly IConfiguration _config;
        private Client _client;

        public SortController(ILogger<SortController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _client = new Client(new HttpClient());
            _client.BaseUrl = _config.GetValue<string>("WooliesXBaseUrl");
        }

        [HttpGet]
        public async Task<ICollection<Product>> Get()
        {
            var products = await _client.ApiResourceProductsGetAsync(_config.GetValue<Guid>("ApiToken"));
            return products;
        }
    }
}
