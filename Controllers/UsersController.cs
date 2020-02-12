using System.Threading.Tasks;
using KmdProject.Api.Interfaces;
using KmdProject.Api.Models.User;
using KmdProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KmdProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            var users = await _userRepository.GetList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            
            var user = await _userRepository.GetAsync(id);
            if(user != null)
            { 
                //Mapster or AutoMapper could be used here.
                var model = new UserDetailsViewModel();
                model.Id = user.Id;
                model.Initials = user.Initials;
                model.Name = user.Name;

                return Ok(model);
            }
            return BadRequest("User not found at database"); // or/and maybe log some strange situation.
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserDetailsViewModel model)
        {
            if(ModelState.IsValid)
            {
                //some validation if user with given name exists if it is important
                var user = await _userRepository.GetAsync(model.Id);
                if(user != null)
                {
                    user.Name = model.Name;
                    user.Initials = model.Initials;
                    await _userRepository.UpdateAsync(user);
                    return Ok("User has been updated");
                }
                return BadRequest("User not found at database");
            }
            return BadRequest("Data validation failed");
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserCreationViewModel model)
        {
            if (ModelState.IsValid)
            {
                //some validation if user with given name exists if it is important.
                var user = new User();
                user.Name = model.Name;
                user.Initials = model.Initials; //Could be created from Name.
                await _userRepository.InsertAsync(user);
                return Ok("User has been added to database.");
            }
            return BadRequest("Data validation failed");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var user = await _userRepository.GetAsync(id);
            if(user != null)
            {
                await _userRepository.DeleteAsync(id);
            }
            else
            {
                //log some strange situation or return appropriate message.
            }
            return Ok("User has been deleted");
        }
    }
}