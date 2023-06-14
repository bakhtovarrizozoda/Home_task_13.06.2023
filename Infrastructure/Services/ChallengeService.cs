using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ChallengeService
{
    private readonly DataContext _context;

    public ChallengeService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<ChallengeBaseDto>> GetChallenges()
    {
        return await _context.Challenges.Select(e => new 
            ChallengeBaseDto()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description
            }).ToListAsync();
    }

    public async Task<ChallengeBaseDto?> GetChallengeById(int id)
    {
        return await _context.Challenges.Select(e => new 
            ChallengeBaseDto()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description
            }).FirstOrDefaultAsync(e =>e.Id == id);
    }

    public async Task<ChallengeBaseDto> AddChallenge(ChallengeBaseDto challenge)
    {
        var challeng = new Challenge(challenge.Id, challenge.Title, challenge.Description);
        await _context.Challenges.AddAsync(challeng);
        await _context.SaveChangesAsync();
        challenge.Id = challeng.Id;
        return challenge;
    }

    public async Task<ChallengeBaseDto> UpdateChallenge(ChallengeBaseDto challenge)
    {
        var find = await _context.Challenges.FindAsync(challenge.Id);
        find.Title = challenge.Title;
        find.Description = challenge.Description;
        await _context.SaveChangesAsync(); 
        return challenge;
    }

    public async Task<bool> DeleteChallenge(int id)
    {
        var find = await _context.Challenges.FindAsync(id);
        _context.Challenges.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}