using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Application;
using WooliesX.Domain.Entities;
using WooliesX.Infrastructure.ApiClient;

namespace WooliesX.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {
        private readonly ILogger<SortController> _logger;
        private readonly IConfiguration _config;
        private IClient _client;

        public ISortManager SortManager { get; }

        public SortController(ILogger<SortController> logger, IConfiguration config, ISortManager sortManager, IClient client)
        {
            _logger = logger;
            _config = config;
            SortManager = sortManager;
            _client = client;
            _client.BaseUrl = _config.GetValue<string>("WooliesXBaseUrl");
        }

        [HttpGet]
        public async Task<ICollection<Product>> Get(SortOptions sortOption)
        {
            if (sortOption != SortOptions.Recommended)
            {
                var products = await _client.ApiResourceProductsGetAsync(_config.GetValue<Guid>("ApiToken"));

                return SortManager.StandardSort(products, sortOption);
                
            }

            var shoppingOrders = await _client.ApiResourceShopperHistoryGetAsync(_config.GetValue<Guid>("ApiToken"));

            return (
                from p in shoppingOrders.SelectMany(o => o.Products)
                group p by p.Name into pgroup
                select new Product { Name = pgroup.Key, Price = pgroup.Average(p => p.Price), Quantity = pgroup.Sum(a => a.Quantity) }
                ).OrderByDescending(x => x.Quantity)
                .ToList();
        }
    }
}
