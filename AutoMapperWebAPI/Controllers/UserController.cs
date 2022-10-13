using AutoMapper;
using AutoMapperWebAPI.DTO;
using AutoMapperWebAPI.Entities;
using AutoMapperWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    // GET: api/<UserController>
    [HttpGet]
    public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
    {
        var users = _userService.GetUsers();
        var dtoUsers = users.Select(u => _mapper.Map<UserDTO>(u));
        return Ok(dtoUsers);
    }

    // GET api/<UserController>/5
    [HttpGet("{id}", Name = "GetUser")]
    public ActionResult<UserDTO> Get(int id)
    {
        if(id == 0)
        {
            return NotFound();
        }
        var entityUser = _userService.GetUser(id);
        return Ok(_mapper.Map<UserDTO>(entityUser));
    }

    // POST api/<UserController>
    [HttpPost]
    public ActionResult Post([FromBody] CreateUserDTO userToCreate)
    {
        if (userToCreate == null)
        {
            return BadRequest();
        }
        var entityUser = _mapper.Map<User>(userToCreate);
        var addedUser = _userService.addUser(entityUser);
        return CreatedAtRoute("GetUser", new {id = addedUser.Id}, addedUser);
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] CreateUserDTO userToUpdate
        )
    {
        if(id == 0)
        {
            return NotFound();
        }
        if (userToUpdate == null)
        {
            return BadRequest();
        }
        var entityUser = _mapper.Map<User>(userToUpdate);
        _userService.UpdateUser(id, entityUser);
        return NoContent();
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _userService.DeleteUser(id);
        return NoContent(); 
    }
}
