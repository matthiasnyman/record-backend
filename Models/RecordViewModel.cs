using System.Collections.Generic;
using record_backend.Models;

public class RecordViewModel {
  public Record Record { get; set; }
  public List<Genre> Genres { get; set;}
}