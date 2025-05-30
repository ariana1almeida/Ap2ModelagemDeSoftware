using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Tutor
{
    [Key]
    public int id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    public string Phone { get; set; } = string.Empty;

    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
}