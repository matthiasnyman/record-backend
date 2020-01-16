using System;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class Order {
    public int Id {get; set;}
    public DateTime Created {get; set;}
    public int CartId {get; set;}
    public Cart Carts {get; set;}

  }
}