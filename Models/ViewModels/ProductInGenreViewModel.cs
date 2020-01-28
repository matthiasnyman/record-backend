using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace record_backend.Models
{
  public class ProductsInGenreViewModel {
    public int Id {get; set;}
    public GenreViewModel Genre {get;set;}

  }
}