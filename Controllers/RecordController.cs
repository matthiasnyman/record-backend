using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public RecordController(IMapper mapper)
    {
      _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<RecordViewModel> Get()
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        List<Record> records = context.Records
          .Include(records => records.ProductsInGenre)
          .ThenInclude(ProductsInGenre => ProductsInGenre.Genre)
          .ToList();

        List<RecordViewModel> viewModels = _mapper.Map<List<RecordViewModel>>(records);

        return viewModels;
      }
    }
    [HttpGet]
    [Route("/recommended")]

    public IEnumerable<RecordViewModel> GetRecommended()
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        List<Record> records = context.Records
          .Where(records => records.Recommended == true)
          // .Include(records => records.ProductsInGenre)
          // .ThenInclude(ProductsInGenre => ProductsInGenre.Genre)
          .ToList();

        List<RecordViewModel> viewModels = _mapper.Map<List<RecordViewModel>>(records);

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
    public IActionResult Post([FromBody] RecordViewModel newRecord)
    {
      Record record = _mapper.Map<Record>(newRecord);


      foreach (ProductsInGenre ProductsInGenre in record.ProductsInGenre)
      {
        ProductsInGenre.Genre = null;
      }

      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        context.Records.Add(record);
        context.SaveChanges();
      }
      return Created("/Record", record);
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
