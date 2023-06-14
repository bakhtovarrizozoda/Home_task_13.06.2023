using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GroupBaseDto>> GetGroup()
    {
        return await _context.Groups.Select(e => new 
            GroupBaseDto()
            {
                Id = e.Id,
                GroupNick = e.GroupNick,
                ChallengeId = e.ChallengeId,
                NeededMember = e.NeededMember,
                TeamSlogan = e.TeamSlogan,
                CreatedAt = e.CreatedAt
            }).ToListAsync();
    }

    public async Task<GetGroupDto?> GetGroupById(int id)
    {
        return await _context.Groups.Select(e => new
            GetGroupDto()
            {
                Id = e.Id,
                GroupNick = e.GroupNick,
                ChallengeId = e.ChallengeId,
                NeededMember = e.NeededMember,
                TeamSlogan = e.TeamSlogan,
                CreatedAt = e.CreatedAt,
                ChallengeTitle = e.Challenge.Title
            }).FirstOrDefaultAsync(e =>e.Id == id);
    }

    public async Task<AddGroupDto> AddGroup(AddGroupDto model)
    {
        try
        {
            //var group = new Group(model.Id, model.GroupNick, model.ChallengeId, model.NeededMember, model.TeamSlogan);
            var group = new Group
            {
                CreatedAt = DateTime.SpecifyKind(model.CreatedAt, DateTimeKind.Utc),
                ChallengeId = model.ChallengeId,
                NeededMember = model.NeededMember,
                TeamSlogan = model.TeamSlogan,
                GroupNick = model.GroupNick
            };
            
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            model.Id = group.Id;
            return model;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<AddGroupDto> UpdateGroup(AddGroupDto group)
    {
        var find = await _context.Groups.FindAsync(group.Id);
        find.GroupNick = group.GroupNick;
        find.ChallengeId = group.ChallengeId;
        find.NeededMember = group.NeededMember;
        find.TeamSlogan = group.TeamSlogan;
        find.CreatedAt = DateTime.SpecifyKind(group.CreatedAt, DateTimeKind.Utc);   
        await _context.SaveChangesAsync();
        return group;
    }

    public async Task<bool> DeleteGroup(int id)
    {
        var find = await _context.Groups.FindAsync(id);
        _context.Groups.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}