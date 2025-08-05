
using Microsoft.AspNetCore.Mvc;
using InventoryApi.Services;
using InventoryApi.Models;
using InventoryApi.Dtos;

namespace InventoryApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly IProductService _service;
        public ProductsController(IProductService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var item = _service.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductDto dto) {
            if (!ModelState.IsValid) return BadRequest();
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto dto) {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();
            _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();
            _service.Delete(id);
            return NoContent();
        }
    }
}
