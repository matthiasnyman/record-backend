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
  public class OrderController : ControllerBase
  {

    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Order> Get()
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        return context.Orders.ToList();
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Order> Get(int id)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        context.Orders.Include(b => b.CartId);
        return context.Orders.First(b => b.Id == id);
      }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Order newOrder)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        context.Orders.Add(newOrder);
        context.SaveChanges();
      }
      return Created("/Order", newOrder);
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        Order toRemove = context.Orders.First(u => u.Id == id);
        context.Orders.Remove(toRemove);
        context.SaveChanges();
      }
      return Ok();
    }
  }
}
