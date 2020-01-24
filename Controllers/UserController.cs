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
  public class UserController : ControllerBase
  {

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        return context.Users
          .Include(user => user.Orders)
          .ThenInclude(order => order.Cart)
          .ToList();
      }
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        using (RecordStoreContexts context = new RecordStoreContexts())
        {
            return context.Users
            .Include(user => user.Orders)
            .First(b => b.Id == id);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] User newUser)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        context.Users.Add(newUser);
        context.SaveChanges();
      }
      return Created("/User", newUser);
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        User RemoveUser = context.Users.First(u => u.Id == id);
        context.Users.Remove(RemoveUser);
        context.SaveChanges();
      }
      return Ok();
    }


    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] User newUser)
    {
      //valideringtest
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        User toUpdate = context.Users.First(u => u.Id == id);
        toUpdate.FirstName = newUser.FirstName;
        toUpdate.LastName = newUser.LastName;
        toUpdate.Email = newUser.Email;

        context.SaveChanges();
      }
      return Ok();
    }
  }
}
