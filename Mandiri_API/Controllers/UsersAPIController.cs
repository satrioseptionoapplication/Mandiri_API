using AutoMapper;
using Mandiri_API.Data;
using Mandiri_API.Models;
using Mandiri_API.Models.Dto;
using Mandiri_API.Repository.IRepostiory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Mandiri_API.Controllers.v1
{
    //[Route("api/[controller]")]
    [Route("api/UsersAPI")]
    [ApiController]
    public class UsersAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUsersRepository _dbUsers;
        private readonly IPositionRepository _dbPosition;
        private readonly ISkillRepository _dbSkill;
        private readonly IProjectRepository _dbProject;
        private readonly IMapper _mapper;
        public UsersAPIController(IUsersRepository dbUsers, IPositionRepository dbPosition, ISkillRepository dbSkill, IProjectRepository dbProject, IMapper mapper)
        {
            _dbUsers = dbUsers;
            _dbPosition = dbPosition;
            _dbSkill = dbSkill;
            _dbProject = dbProject;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllUsers()
        {
            try
            {
                var users = await _dbUsers.GetAllAsync();
                _response.Result = _mapper.Map<List<UsersDTO>>(users);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("{Id:long}", Name = "GetUsersById")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetUsersById(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                _response.Result = _mapper.Map<UsersDTO>(await _dbUsers.GetByIdAsync(g => g.Id == Id));
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [Route("GetUsersDetail")]
        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetUsersDetail(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                UsersDetail data = new UsersDetail();
                data.Users = _dbUsers.GetByIdAsync(g => g.Id == Id).Result;
                data.Position = _dbPosition.GetByIdAsync(g => g.UsersId == Id).Result;
                data.Skill = _dbSkill.GetByUsersIdAsync(Id).Result;
                data.ProjectUsers = _dbProject.GetByUsersIdAsync(Id).Result;
                _response.Result = _mapper.Map<UsersDetail>(data);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateUsers([FromBody] UsersDTO usersDTO)
        {
            try
            {
                if (usersDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(usersDTO);
                }
                if (usersDTO.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Users model = _mapper.Map<Users>(usersDTO);
                await _dbUsers.CreateAsync(model);

                _response.Result = _mapper.Map<UsersDTO>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetUsersById", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;


        }

        [Route("CreateUsersDetail")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateUsersDetail([FromBody] UsersDetailDTO usersDTO)
        {
            try
            {
                if (usersDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(usersDTO);
                }
                if (usersDTO.Users.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                UsersDetail model = _mapper.Map<UsersDetail>(usersDTO);
                await _dbUsers.CreateUsersDetailAsync(model);

                _response.Result = _mapper.Map<UsersDetail>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetUsersById", new { id = model.Users.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Route("UpdateUsersDetail")]
        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateUsersDetail([FromBody] UsersDetailDTO usersDTO)
        {
            try
            {
                if (usersDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(usersDTO);
                }
                if (await _dbPosition.GetByIdAsync(u => u.Id == usersDTO.Position.Id) == null)
                {
                    return NotFound();
                }

                UsersDetail model = _mapper.Map<UsersDetail>(usersDTO);
                await _dbUsers.UpdateUsersDetail(model);

                _response.Result = _mapper.Map<UsersDetail>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetUsersById", new { id = model.Users.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{Id:long}", Name = "DeleteUsers")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteUsers(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                var users = await _dbUsers.GetByIdAsync(f => f.Id == Id);
                if (users == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }
                await _dbUsers.RemoveAsync(users);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateUsers([FromBody] UsersDTO usersDTO)
        {
            try
            {
                if (usersDTO.Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                Users model = _mapper.Map<Users>(usersDTO);
                await _dbUsers.UpdateAsync(model);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
