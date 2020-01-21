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
  public class GenreController : ControllerBase
  {

    private readonly ILogger<GenreController> _logger;

    public GenreController(ILogger<GenreController> logger)
    {
      _logger = logger;
    }

    // [HttpGet]
    // public IEnumerable<Genre> Get()
    // {
    //   using (RecordStoreContexts context = new RecordStoreContexts())
    //   {
    //     return context.Genres
    //       .Include(genre => genre.ProductsInGenre)
    //       .ThenInclude(pig => pig.Record)
    //       .ToList();
    //   }
    // }

    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        using (RecordStoreContexts context = new RecordStoreContexts())
        {
            return context.Genres
            .Include( genre => genre.ProductsInGenre )
            .ThenInclude(pig => pig.Record)
            .First(b => b.Id == id);
              
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Genre newGenres)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        context.Genres.Add(newGenres);
        context.SaveChanges();
      }
      return Created("/Genres", newGenres);
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        Genre RemoveGenres = context.Genres.First(u => u.Id == id);
        context.Genres.Remove(RemoveGenres);
        context.SaveChanges();
      }
      return Ok();
    }


    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] Genre newGenres)
    {
      //valideringtest
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        Genre toUpdate = context.Genres.First(u => u.Id == id);
        toUpdate.Name = newGenres.Name;

        context.SaveChanges();
      }
      return Ok();
    }
  }
}
