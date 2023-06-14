using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChallengeController
{
    private readonly ChallengeService _challengeService;

    public ChallengeController(ChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet("GetChallenge")]
    public async Task<List<ChallengeBaseDto>> GetChallenge()
    {
        return await _challengeService.GetChallenges();
    }

    [HttpGet("GetById")]
    public async Task<ChallengeBaseDto> GetChallengeById(int id)
    {
        return await _challengeService.GetChallengeById(id);
    }

    [HttpPost("AddChallenge")]
    public async Task<ChallengeBaseDto> AddChallenge([FromForm]ChallengeBaseDto challenge)
    {
        return await _challengeService.AddChallenge(challenge);
    }

    [HttpPut("UpdateChallenge")]
    public async Task<ChallengeBaseDto> UpdateChallenge([FromForm]ChallengeBaseDto challenge)
    {
        return await _challengeService.UpdateChallenge(challenge);
    }

    [HttpDelete("DeleteChallenge")]
    public async Task<bool> DeleteChallenge(int id)
    {
        return await _challengeService.DeleteChallenge(id);
    }
}