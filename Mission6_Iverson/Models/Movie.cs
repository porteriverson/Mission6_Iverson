using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission6.Models;


public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Categories? Category { get; set; }
    public string Title { get; set; }
    [Range(1888, 2025, ErrorMessage = "Please enter a year between 1888 and 2025")]
    [Required]
    public int? Year { get; set; }
    
    public string? Director { get; set; }
    public  string? Rating { get; set; }
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
}
