using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace record_backend.Models
{
  public class Record {
    public int Id {get; set;}
    [Required]
    public string Artist {get; set;}
    [Required]
    public string Album {get; set;}
    public string Image {get; set;}
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price {get; set;}
    public decimal Sale {get; set;}
    public string Info {get; set;}
    public IEnumerable<ProductsInGenre> ProductsInGenre {get; set;}
  }
}