using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using SpecPattern.Dtos;
using SpecPattern.Models;
using SpecPattern.Specifications;

namespace SpecPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    
    private readonly List<User> _users = new()
    {
        new()
        {
            Name = "Damir",
            Surname = "Nabiullin",
            IsActive = true
        },
        new()
        {
            Name = "Liza",
            Surname = "Chusova",
            IsActive = true
        },
        new()
        {
            Name = "Danil",
            Surname = "Lopkin",
            IsActive = false
        },
    };

    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var activeUsers = _users
            .AsQueryable()
            .Where(UserSpecifications.IsActive)
            .ProjectTo<GetUserDto>(_mapper.ConfigurationProvider)
            .ToList();


        return Ok(activeUsers);
    }
}