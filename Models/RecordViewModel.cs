using System.Collections.Generic;
using record_backend.Models;

public class RecordViewModel {
  public List<Genre> Genres { get; set;}
  public int RecordId { get; set; }
  public Record Record { get; set; }
}

