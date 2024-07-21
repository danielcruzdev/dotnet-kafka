using InventoryProducer.Models;
using InventoryProducer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InventoryProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ProducerService _producerService;

        public InventoryController(ProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventory()
        {
            var random = new Random();
            
            var request = new InventoryUpdateRequest
            {
                ProductId = Guid.NewGuid().ToString(),
                Quantity = random.Next(1, 10000),
                Id = random.Next(1, 10000)
            };

            var message = JsonSerializer.Serialize(request);

            await _producerService.ProduceAsync("InventoryUpdates", message);

            return Ok("Inventory Updated Successfully...");
        }
    }
}
