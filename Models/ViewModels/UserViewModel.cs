using System.Collections.Generic;

namespace record_backend.Models
{
  public class UserViewModel {
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public List<OrderViewModel> OrderViewModels {get; set;}

  }
}