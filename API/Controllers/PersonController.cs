using Microsoft.AspNetCore.Mvc;
using WikiF1.API.Models;
using WikiF1.API.Services;

namespace WikiF1.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    // public PersonController
    // {
    // }

    [HttpGet]
    public ActionResult<List<Person>> GetAll() => PersonService.GetAll();

    [HttpGet("drivers")]
    public ActionResult<List<Person>> GetDrivers() => PersonService.GetDrivers();
    
    [HttpGet("team_principals")]
    public ActionResult<List<Person>> GetTeamPrincipals() => PersonService.GetTeamPrincipals();

    [HttpGet("{id:int}")]
    public ActionResult<Person> GetById(int id)
    {
        var person = PersonService.Get(id);

        if (person is null) return NotFound();

        return person;
    }


    [HttpPost]
    public IActionResult Create(Person person)
    {
        PersonService.Add(person);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Person person)
    {
        if (id != person.Id) return BadRequest();

        var existingPerson = PersonService.Get(id);
        if (existingPerson is null) return NotFound();
        
        PersonService.Update(person);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var person = PersonService.Get(id);

        if (person is null) return NotFound();
        
        PersonService.Delete(id);
        return NoContent();
    }
}