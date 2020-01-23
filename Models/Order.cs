using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class Order {
    public int Id {get; set;}
    public DateTime Created {get; set;}
    public List<Cart> CartId {get; set;}
    public int UserId {get; set;}

    // public Cart Carts {get; set;}

  }
}