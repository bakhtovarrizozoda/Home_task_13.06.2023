using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Group
{
    public Group()
    {
        
    }
    public Group(int groupId, string groupGroupNick, int groupChallengeId, bool groupNeededMember, string groupTeamSlogan )
    {
        GroupNick = groupGroupNick;
        ChallengeId = groupChallengeId;
        NeededMember = groupNeededMember;
        TeamSlogan = groupTeamSlogan;
        
    }
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string GroupNick { get; set; }
    [Required]
    public int ChallengeId { get; set; }
    [Required]
    public bool NeededMember { get; set; }
    [Required]
    public string TeamSlogan { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    public ICollection<Participant> Participant { get; set; }
    public Challenge Challenge { get; set; }
}