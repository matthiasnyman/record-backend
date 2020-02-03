using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class Order {
    public int Id {get; set;}
    public DateTime Created {get; set;}
    public List<Cart> Cart {get; set;}
    public int UserId {get; set;}

    //public User User {get;set;}

  }
}