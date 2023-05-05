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
    [Route("api/SkillAPI")]
    [ApiController]
    public class SkillAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ISkillRepository _dbSkill;
        private readonly IMapper _mapper;
        public SkillAPIController(ISkillRepository dbSkill, IMapper mapper)
        {
            _dbSkill = dbSkill;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllSkill()
        {
            try
            {
                var users = await _dbSkill.GetAllAsync();
                _response.Result = _mapper.Map<List<SkillDTO>>(users);
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

        [HttpGet("{Id:long}", Name = "GetSkillById")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetSkillById(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                _response.Result = _mapper.Map<SkillDTO>(await _dbSkill.GetByIdAsync(g => g.Id == Id));
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
        public async Task<ActionResult<APIResponse>> CreateSkill([FromBody] SkillDTO usersDTO)
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
                Skill model = _mapper.Map<Skill>(usersDTO);
                await _dbSkill.CreateAsync(model);

                _response.Result = _mapper.Map<SkillDTO>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetSkillById", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;


        }

        [HttpDelete("{Id:long}", Name = "DeleteSkill")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteSkill(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                var users = await _dbSkill.GetByIdAsync(f => f.Id == Id);
                if (users == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }
                await _dbSkill.RemoveAsync(users);
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
        public async Task<ActionResult<APIResponse>> UpdateSkill([FromBody] SkillDTO usersDTO)
        {
            try
            {
                if (usersDTO.Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                Skill model = _mapper.Map<Skill>(usersDTO);
                await _dbSkill.UpdateAsync(model);

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
