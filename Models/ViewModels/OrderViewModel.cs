using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class OrderViewModel {
    public List<CartViewModel> CartViewModels {get; set;}
    public int UserId {get; set;}

  }
}