using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutomationExercise.Models;
using AutomationExercise.Services.Abstract;

namespace AutomationExercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _service;
        
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> people = _service.Get();
            return people;
        }

        [HttpGet]
        [Route("{id?}")]
        public Person GetById(string id)
        {
            if (id == null)
                return null;

            Person kisi = _service.Get(id);

            return kisi;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if(ModelState.IsValid)
            {
                _service.Create(person);
                return Created(person.Id.ToString(), person);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id?}")]
        public IActionResult Put(string id, [FromBody] Person person)
        {
            if (id == null)
                return NoContent();

            Person _person = _service.Get(id);

            if (_person == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            person.Id = id;
            long result = _service.Update(id, person);

            if(result > 0)
                return Ok(person);
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("{id?}")]
        public IActionResult Delete(string id)
        {
            if (id == null)
                return NoContent();

            Person _person = _service.Get(id);

            if (_person == null)
                return NotFound();

            long result = _service.Remove(id);

            if(result > 0)
                return Ok(_person);
            else
                return BadRequest();
        }
    }
}
