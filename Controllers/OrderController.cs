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
  public class OrderController : ControllerBase
  {
    private readonly IMapper _mapper;

    public OrderController(IMapper mapper)
    {
      _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Order> Get()
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        return context.Orders
          .Include(order => order.Cart)
          .ThenInclude(cart => cart.Record)
          .ToList();

      }
    }

    [HttpGet("{id}")]
    public ActionResult<Order> Get(int id)
    {
      using (RecordStoreContexts context = new RecordStoreContexts())
      {
        return context.Orders.First(b => b.Id == id);
      }
    }

    [HttpPost]
    public IActionResult Post([FromBody] OrderViewModel newOrder)
    {

      Order order = _mapper.Map<Order>(newOrder);

      using (RecordStoreContexts context = new RecordStoreContexts())
      {

        User userExists = context.Users.FirstOrDefault(User => User.Email == newOrder.Email);

        int userId = 0;
        if(userExists == null){
          User u = new User();
          u.FirstName  = newOrder.FirstName;
          u.LastName  = newOrder.LastName;
          u.Email  = newOrder.Email;
          context.Users.Add(u);
          context.SaveChanges();
          userId = u.Id;
        }
        else {
          userId = userExists.Id;
        }
      

        Order o = new Order();
        o.Created = DateTime.Now;
        o.UserId = userId;
        context.Orders.Add(o);
        context.SaveChanges();

        foreach (Cart cart in order.Cart)
        {
          Cart c = new Cart();
          c.RecordId = cart.RecordId;
          c.OrderId = o.Id;
          context.Carts.Add(c);

          context.SaveChanges();
        }

        return Created("/Order", o);
      }
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
