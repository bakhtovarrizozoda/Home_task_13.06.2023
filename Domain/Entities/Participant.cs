using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Participant
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string FullName { get; set; }
    [Required,MaxLength(50)]
    public string Email { get; set; }
    [Required,MaxLength(50)]
    public string Phone { get; set; }
    [Required,MaxLength(50)]
    public string Password { get; set; }
    [Required]
    public DateTime CreateAt { get; set; }
    [Required]
    public int GroupId { get; set; }
    [Required]
    public int LocationId { get; set; }
    public Group Group { get; set; }
    public Location Location { get; set; }
}
