using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IDattingRepository _repo { get; }
        public IMapper _mapper { get; }
        
        public UsersController(IDattingRepository _repo, IMapper _mapper)
        {
            this._mapper = _mapper;
            
            this._repo = _repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var Users = await _repo.getUsers();
            var UsersToReturn = _mapper.Map<IEnumerable<UserForListDtos>>(Users);
            return Ok(UsersToReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var user = await _repo.GetUser(id);
            var UserToReturn= _mapper.Map<UserForDetailsDtos>(user);
            return Ok(UserToReturn);
        }

    }
}