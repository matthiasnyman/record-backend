using System.Collections.Generic;

namespace record_backend.Models
{
  public class Genre {
    public int Id {get; set;}
    public string Name {get; set;}
    public List<ProductsInGenre> ProductsInGenre {get; set;}

  }
}