using Microsoft.AspNetCore.Mvc;
using WikiF1.API.Models;
using WikiF1.API.Services;

namespace WikiF1.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TrackController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Record>> GetAll() => RecordService.getAll();

    [HttpGet("{id:int}")]
    public ActionResult<Record> GetById(int id)
    {
        var record = RecordService.Get(id);

        if (record is null) return NotFound();

        return record;
    }


    [HttpPost]
    public IActionResult Create(Record record)
    {
        RecordService.Add(record);
        return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Record record)
    {
        if (id != record.Id) return BadRequest();

        var existingRecord = RecordService.Get(id);
        if (existingRecord is null) return NotFound();
        
        RecordService.Update(existingRecord);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var record = RecordService.Get(id);

        if (record is null) return NotFound();
        
        RecordService.Delete(id);
        return NoContent();
    }
}