using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Challenge
{
    public Challenge()
    {
        
    }
    public Challenge(int challengeId, string challengeTitle, string challengeDescription)
    {
        Id = challengeId;
        Title = challengeTitle;
        Description = challengeDescription;
    }

    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Title { get; set; }
    [Required, MaxLength(50)]
    public string Description { get; set; }
    public ICollection<Group> Groups { get; set; }
}