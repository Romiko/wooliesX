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
    public class SortController : ControllerBase
    {
        public enum SortOptions { Low, High, Ascending, Descending, Recommended }

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
        public async Task<ICollection<Product>> Get(SortOptions sortOption)
        {
            if (sortOption != SortOptions.Recommended)
            {
                var products = await _client.ApiResourceProductsGetAsync(_config.GetValue<Guid>("ApiToken"));

                switch (sortOption)
                {
                    case SortOptions.Low:
                        return products.OrderBy(p => p.Price).ToList();
                    case SortOptions.High:
                        return products.OrderByDescending(p => p.Price).ToList();
                    case SortOptions.Ascending:
                        return products.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();
                    case SortOptions.Descending:
                        return products.OrderByDescending(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();
                    default:
                        return products;
                }
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
