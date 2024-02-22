using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCardStatus.Dto;
using WebApiCardStatus.Interfaces;
using WebApiCardStatus.Models;
using WebApiCardStatus.Repository;

namespace WebApiCardStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UsersDto>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UsersDto>>(_usersRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UsersDto))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int id)
        {
            if (!_usersRepository.UserExist(id))
                return NotFound();

            var user = _mapper.Map<UsersDto>(_usersRepository.GetUser(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UsersDto))]
        [ProducesResponseType(400)]
        public IActionResult AddUser([FromBody] UsersDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToAdd = _mapper.Map<Users>(userDto);
            _usersRepository.AddUser(userToAdd);

            return CreatedAtAction(nameof(GetUser), new { id = userToAdd.Id }, userDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser(int id, [FromBody] UsersDto userDto)
        {
            if (userDto == null || id != userDto.Id)
            {
                return BadRequest("Invalid user object");
            }

            if (!_usersRepository.UserExist(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToUpdate = _mapper.Map<Users>(userDto);
            _usersRepository.UpdateUser(userToUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int id)
        {
            if (!_usersRepository.UserExist(id))
            {
                return NotFound();
            }

            _usersRepository.DeleteUser(id);

            return NoContent();
        }
    }
}
