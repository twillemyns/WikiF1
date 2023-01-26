using Microsoft.AspNetCore.Mvc;
using WikiF1.API.Models;
using WikiF1.API.Services;

namespace WikiF1.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RecordController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Record>> Get() => RecordService.getAll();

    [HttpGet("{id:int}")]
    public ActionResult<Record> GetById(int id)
    {
        var record = RecordService.Get(id);
        if (record is null) return NotFound();

        return record;
    }

    [HttpPost]
    public IActionResult Create(Team team)
    {
        TeamService.Add(team);
        return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Team team)
    {
        if (id != team.Id) return BadRequest();

        var existingTeam = TeamService.Get(id);
        if (existingTeam is null) return NotFound();
        
        TeamService.Update(team);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var team = TeamService.Get(id);
        if (team is null) return NotFound();
        
        TeamService.Delete(id);
        return NoContent();
    }
}