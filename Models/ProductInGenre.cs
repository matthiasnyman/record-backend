using System.Collections.Generic;
using System.Text.Json.Serialization;

// för att få ut alla album som finns i en genre 

namespace record_backend.Models
{
  public class ProductsInGenre {
    public int Id {get; set;}
    public int GenreId {get; set;}
    public int RecordId {get; set;}
    [JsonIgnore]
    public Genre Genre {get; set;}
    public Record Record {get; set;}
  }
}