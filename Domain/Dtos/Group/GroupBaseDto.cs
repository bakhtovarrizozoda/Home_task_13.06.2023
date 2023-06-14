namespace Domain.Entities;

public class GroupBaseDto
{
    public int Id { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
}