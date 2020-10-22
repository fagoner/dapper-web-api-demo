using System.ComponentModel.DataAnnotations;

namespace DapperRest.Api.Models
{
  public class Actor
  {

    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public override string ToString() {
      return $"Id:{Id},  Name: '{Name}']";
    }
  }
}