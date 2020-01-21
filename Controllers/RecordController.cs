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
    public IEnumerable<RecordViewModel> Get()
    {
      List<RecordViewModel> viewModels = new List<RecordViewModel>();

      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        List<Record> rs = context.Records.Include(record => record.ProductsInGenre).ToList();

        foreach(var r in rs) {

          RecordViewModel viewModel = new RecordViewModel();
          viewModel.Record = r;

          List<ProductsInGenre> pigs = context.ProductsInGenre
            .Where(pig => pig.RecordId == r.Id)
            .ToList();

          List<Genre> genres = new List<Genre>();
          foreach(var g in pigs){
            Genre genre = context.Genres.FirstOrDefault(genre => genre.Id == g.GenreId);
            genres.Add(genre);
          }

          viewModel.Genres = genres;

          viewModels.Add(viewModel);
        }

        return viewModels;
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
