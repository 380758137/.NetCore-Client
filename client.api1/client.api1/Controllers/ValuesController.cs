using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;

namespace client.api1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DiscoveryHttpClientHandler _handler;
        private const string ProductUrl = "http://product/api/values";

        public ValuesController(IDiscoveryClient client,ILoggerFactory loggerFactory)
        {
            _handler = new DiscoveryHttpClientHandler(client);
        }

        // GET api/values
        [HttpGet("product")]
        public async Task<string> GetProductAsync()
        {
            var client = new HttpClient(_handler, false);
            return await client.GetStringAsync(ProductUrl);
        }

    }
}
