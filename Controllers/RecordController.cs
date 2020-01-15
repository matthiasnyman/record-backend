using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkUppgift.contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using record_backend.Models;

namespace record_backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RecordController : ControllerBase
  {

    private readonly ILogger<RecordController> _logger;

    public RecordController(ILogger<RecordController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Record> Get()
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        return context.Records.ToList();

      }
    }

    [HttpGet("{id}")]
    public ActionResult<Record> Get(int id)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        return context.Records.First(b => b.Id == id);
      }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Record newRecord)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        context.Records.Add(newRecord);
        context.SaveChanges();
      }
      return Created("/Record", newRecord);
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        Record toRemove = context.Records.First(u => u.Id == id);
        context.Records.Remove(toRemove);
        context.SaveChanges();
      }
      return Ok();
    }


    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] Record newRecord)
    {
      //validering

      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        Record toUpdate = context.Records.First(u => u.Id == id);
        toUpdate.Artist = newRecord.Artist;
        toUpdate.Album = newRecord.Album;
        toUpdate.Image = newRecord.Image;
        toUpdate.Info = newRecord.Info;
        toUpdate.Price = newRecord.Price;

        context.SaveChanges();
      }
      return Ok();
    }
  }
}
