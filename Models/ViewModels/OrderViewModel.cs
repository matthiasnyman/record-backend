using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class OrderViewModel {
    public List<CartViewModel> Cart {get; set;}
    public int UserId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}

  }
}


