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
    [Route("api/ProjectAPI")]
    [ApiController]
    public class ProjectAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IProjectRepository _dbProject;
        private readonly IMapper _mapper;
        public ProjectAPIController(IProjectRepository dbProject, IMapper mapper)
        {
            _dbProject = dbProject;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllProject()
        {
            try
            {
                var project = await _dbProject.GetAllAsync();
                _response.Result = _mapper.Map<List<ProjectDTO>>(project);
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

        [HttpGet("{Id:long}", Name = "GetProjectById")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProjectById(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                _response.Result = _mapper.Map<ProjectDTO>(await _dbProject.GetByIdAsync(g => g.Id == Id));
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
        public async Task<ActionResult<APIResponse>> CreateProject([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                if (projectDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(projectDTO);
                }
                if (projectDTO.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Project model = _mapper.Map<Project>(projectDTO);
                await _dbProject.CreateAsync(model);

                _response.Result = _mapper.Map<ProjectDTO>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetProjectById", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;


        }

        [HttpDelete("{Id:long}", Name = "DeleteProject")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteProject(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                var project = await _dbProject.GetByIdAsync(f => f.Id == Id);
                if (project == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }
                await _dbProject.RemoveAsync(project);
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
        public async Task<ActionResult<APIResponse>> UpdateProject([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                if (projectDTO.Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                Project model = _mapper.Map<Project>(projectDTO);
                await _dbProject.UpdateAsync(model);

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
