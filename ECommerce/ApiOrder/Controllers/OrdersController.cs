using ApiOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Threading.Tasks;

namespace ApiOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ElasticClient _elasticClient;
        public OrdersController(ElasticClient elasticClient)
            => _elasticClient = elasticClient;


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
           var result = await _elasticClient.IndexAsync(order, x => x.Index("order"));

            return Ok();
        }
    }
}