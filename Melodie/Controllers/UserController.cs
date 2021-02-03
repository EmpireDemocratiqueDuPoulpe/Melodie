using System.Collections.Generic;
using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Melodie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMelodieDbService _dbService;

        public UserController(ILogger<UserController> logger, IMelodieDbService service)
        {
            _logger = logger;
            _dbService = service;
        }
        
        // GET
        [HttpGet("{uid}", Name = "GetById")]
        public async Task<ActionResult<User>> Get(int userId)
        {
            var user = await _dbService.GetUserById(userId);
            return (user != default) ? Ok(user) : NotFound();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _dbService.GetAllUsers();
        }
        
        // ADD
        [HttpPost]
        public async Task<ActionResult<User>> Add(User user)
        {
            if (user.UserId != null)
            {
                return BadRequest("ID cannot be set for INSERT query.");
            }

            var userId = await _dbService.AddUser(user);
            return (user != default) ? CreatedAtRoute("GetById", new {uid = userId}, user) : BadRequest();
        }
        
        // UPDATE
        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            if (user.UserId == null)
            {
                return BadRequest("ID must be set for UPDATE query.");
            }

            var result = await _dbService.UpdateUser(user);
            return (result > 0) ? NoContent() : NotFound();
        }
        
        // DELETE
        [HttpDelete("{uid}")]
        public async Task<ActionResult<User>> Delete(int userId)
        {
            var result = await _dbService.DeleteUser(userId);
            return (result > 0) ? NoContent() : NotFound();
        }
        
    }
}