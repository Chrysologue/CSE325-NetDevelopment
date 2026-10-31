using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;
namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
            
        }
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            var pizzas = PizzaService.GetAll();
            return pizzas;
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }
        [HttpPost]
        public ActionResult Create(Pizza pizza)
        {
            PizzaService.AddPizza(pizza);
            return CreatedAtAction(nameof(Get), new{id=pizza.Id}, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();
            
            PizzaService.Delete(id);

            return NoContent();
        }
    }
}