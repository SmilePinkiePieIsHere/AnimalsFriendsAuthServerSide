using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using AnimalsFriends.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AnimalsFriends.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;           
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll([FromQuery] AnimalQueryParameters queryParameters)
        {
            return Ok(_animalService.GetAll(queryParameters)); 
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetAnimal(int id)
        {
            var animal = _animalService.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public ActionResult AddAnimal([FromBody] Animal animal)
        {
            _animalService.AddAnimal(animal);
           var test = CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
            return Ok(animal);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAnimal([FromRoute] int id, [FromBody] Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            try
            {
                _animalService.UpdateAnimal(animal);               
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (_context.Animals.Find(id) == null)
                //{
                //    return NotFound();
                //}

                return NotFound();

                throw;
            }

            return Ok(animal); /// NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAnimal([FromRoute] int id)
        {
            var animal = _animalService.FindAnimal(id);

            if (animal == null)
            {
                return NotFound();
            }

            _animalService.DeleteAnimal(animal);

            return Ok(animal); //(ActionResult)animal
        }
    }
}
