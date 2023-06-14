using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController
{
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("GetGroup")]
    public async Task<List<GroupBaseDto>> GetGroup()
    {
        return await _groupService.GetGroup();
    }

    [HttpGet("GetById")]
    public async Task<GetGroupDto?> GetGroupById(int id)
    {
        return await _groupService.GetGroupById(id);
    }

    [HttpPost("AddGroup")]
    public async Task<AddGroupDto> AddGroup([FromBody]AddGroupDto group)
    {
        return await _groupService.AddGroup(group);
    }

    [HttpPut("UpdateGroup")]
    public async Task<AddGroupDto> UpdateGroup([FromForm]AddGroupDto group)
    {
        return await _groupService.UpdateGroup(group);
    }

    [HttpDelete("DeleteGroup")]
    public async Task<bool> DeleteGroup(int id)
    {
        return await _groupService.DeleteGroup(id);
    }
}