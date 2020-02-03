using System.Collections.Generic;
using System.Text.Json.Serialization;
using record_backend.Models;


// viewModel för att kunna hämta alla records + genre

namespace record_backend.Models
{
  public class RecordViewModel 
  {
    public List<ProductsInGenreViewModel> ProductsInGenre { get; set;}
    public int Id {get; set;}
    public string Artist {get; set;}
    public string Album {get; set;}
    public string Image {get; set;}    
    public decimal Price {get; set;}
    public decimal Sale {get; set;}
    public string Info {get; set;}
    public bool Recommended {get; set;}
  }
}

