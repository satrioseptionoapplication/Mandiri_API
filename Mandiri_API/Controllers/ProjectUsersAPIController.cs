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
    [Route("api/ProjectUsersAPI")]
    [ApiController]
    public class ProjectUsersAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IProjectUsersRepository _dbProjectUsers;
        private readonly IMapper _mapper;
        public ProjectUsersAPIController(IProjectUsersRepository dbProjectUsers, IMapper mapper)
        {
            _dbProjectUsers = dbProjectUsers;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllProjectUsers()
        {
            try
            {
                var projectUsers = await _dbProjectUsers.GetAllAsync();
                _response.Result = _mapper.Map<List<ProjectUsersDTO>>(projectUsers);
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

        [HttpGet("{Id:long}", Name = "GetProjectUsersById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProjectUsersById(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                _response.Result = _mapper.Map<ProjectUsersDTO>(await _dbProjectUsers.GetByIdAsync(g => g.Id == Id));
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateProjectUsers([FromBody] ProjectUsersDTO projectUsersDTO)
        {
            try
            {
                if (projectUsersDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(projectUsersDTO);
                }
                if (projectUsersDTO.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                ProjectUsers model = _mapper.Map<ProjectUsers>(projectUsersDTO);
                await _dbProjectUsers.CreateAsync(model);

                _response.Result = _mapper.Map<ProjectUsersDTO>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetProjectUsersById", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;


        }

        [HttpDelete("{Id:long}", Name = "DeleteProjectUsers")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteProjectUsers(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                var projectUsers = await _dbProjectUsers.GetByIdAsync(f => f.Id == Id);
                if (projectUsers == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }
                await _dbProjectUsers.RemoveAsync(projectUsers);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateProjectUsers([FromBody] ProjectUsersDTO projectUsersDTO)
        {
            try
            {
                if (projectUsersDTO.Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                ProjectUsers model = _mapper.Map<ProjectUsers>(projectUsersDTO);
                await _dbProjectUsers.UpdateAsync(model);

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
