using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class Cart {
    public int Id {get; set;}
    public int UserId {get; set;}
    public int RecordId {get; set;}

    public User User {get; set;}
    public Record Record {get; set;}
  }
}