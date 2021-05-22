using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using AnimalsFriends.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;

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
        public ActionResult GetAnimal(string id)
        {
            var animal = _animalService.Get(Guid.Parse(id));
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public ActionResult AddAnimal([FromBody] Animal animal)
        {
            _animalService.Add(animal);
            CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
            return Ok(animal);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAnimal([FromRoute] string id, [FromBody] Animal animal)
        {
            if (id != animal.Id.ToString())
            {
                return BadRequest();
            }

            try
            {
                _animalService.Update(animal);               
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAnimal([FromRoute] string id)
        {
            var animal = _animalService.Find(Guid.Parse(id));

            if (animal == null)
            {
                return NotFound();
            }

            _animalService.Delete(animal);

            return Ok(animal); //(ActionResult)animal
        }
    }
}
