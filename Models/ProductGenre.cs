using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class ProductGenre {
    public int Id {get; set;}
    public int GenreId {get; set;}
    public int RecordId {get; set;}
    public Genre Genre {get; set;}
    public Record Record {get; set;}
  }
}