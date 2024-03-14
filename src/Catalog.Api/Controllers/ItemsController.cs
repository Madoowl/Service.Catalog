using Catalog.Api.DTO;
using Catalog.Api.Models;
using Catalog.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        protected readonly IRepository<Item> _repository;

        public ItemsController(IRepository<Item> repository)
        {
            _repository = repository;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Item> items = await _repository.GetListAsync();
            return items.Count() > 0 ? Ok(items) : NotFound();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IEnumerable<Item> items = await _repository.GetListAsync();

            Item item = items.First(i => i.Id == id);

            return item != null ? Ok(item) : NotFound();
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemEditDto itemDto)
        {
            Item item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description
            };

            Item itemReturn = await _repository.Add(item);

            return itemReturn != null ? Ok(itemReturn) : BadRequest();

        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ItemEditDto itemDto)
        {
            Item item = new Item
            {
                Id = id,
                Name = itemDto.Name,
                Description = itemDto.Description
            };
            Item itemReturn = await _repository.Add(item);

            return itemReturn != null ? Ok(itemReturn) : BadRequest();


        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IEnumerable<Item> items = await _repository.GetListAsync();

            Item item = items.First(i => i.Id == id);

            if (item != null)
            {
                try
                {
                    _repository.Delete(item);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
            else
            {
                return NotFound();
            }
        }
    }
}
