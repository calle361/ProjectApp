using System.ComponentModel.DataAnnotations;
namespace ProjectApp.Models;

public class CreateProjectVm
{
 [Required]
 [StringLength(128,ErrorMessage = "Project name cannot be longer than 128 characters.")]
 public string? Title { get; set; }
}