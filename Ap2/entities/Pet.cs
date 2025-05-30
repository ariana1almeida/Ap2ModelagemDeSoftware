using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pet
{
    [Key]
    public int PetId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Especies { get; set; } = string.Empty;

    [Required]
    public string Breed { get; set; } = string.Empty;

    [Required]
    public int TutorId { get; set; }

    [ForeignKey("TutorId")]
    public Tutor? Tutor { get; set; }
}