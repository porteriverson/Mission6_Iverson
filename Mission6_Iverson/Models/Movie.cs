using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission6.Models;


public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    public string MovieTitle { get; set; }
    public string MovieCategory { get; set; }
    public string Year { get; set; }
    public string Director { get; set; }
    public  string Rating { get; set; } 
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    public string? Notes { get; set; }
}
