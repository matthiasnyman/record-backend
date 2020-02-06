using System.Collections.Generic;
using System.Text.Json.Serialization;
  // cart = orderRow....
namespace record_backend.Models
{
  public class Cart {
    public int Id {get; set;}
    public int RecordId {get; set;}
    public int OrderId {get; set;}
    public Record Record {get; set;}

  }
}