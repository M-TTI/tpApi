using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tpApi.Models.Enums;

namespace tpApi.Models;

[Table("forecast")]
public class Forecast
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("city")]
    public City City { get; set; }
    
    [Required]
    [Column("temperature")]
    public float Temperature { get; set; }
    
    [Required]
    [Column("condition")]
    public Condition Condition { get; set; }
    
    [Required]
    [Column("date")]
    public DateTime Date { get; set; }
}