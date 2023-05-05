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
    [Route("api/PositionAPI")]
    [ApiController]
    public class PositionAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IPositionRepository _dbPosition;
        private readonly IMapper _mapper;
        public PositionAPIController(IPositionRepository dbPosition, IMapper mapper)
        {
            _dbPosition = dbPosition;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllPosition()
        {
            try
            {
                var position = await _dbPosition.GetAllAsync();
                _response.Result = _mapper.Map<List<PositionDTO>>(position);
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

        [HttpGet("{Id:long}", Name = "GetPositionById")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetPositionById(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                _response.Result = _mapper.Map<PositionDTO>(await _dbPosition.GetByIdAsync(g => g.Id == Id));
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
        public async Task<ActionResult<APIResponse>> CreatePosition([FromBody] PositionDTO positionDTO)
        {
            try
            {
                if (positionDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(positionDTO);
                }
                if (positionDTO.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Position model = _mapper.Map<Position>(positionDTO);
                await _dbPosition.CreateAsync(model);

                _response.Result = _mapper.Map<PositionDTO>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetPositionById", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;


        }

        [HttpDelete("{Id:long}", Name = "DeletePosition")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeletePosition(long Id)
        {
            try
            {
                if (Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                var position = await _dbPosition.GetByIdAsync(f => f.Id == Id);
                if (position == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }
                await _dbPosition.RemoveAsync(position);
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
        public async Task<ActionResult<APIResponse>> UpdatePosition([FromBody] PositionDTO positionDTO)
        {
            try
            {
                if (positionDTO.Id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                Position model = _mapper.Map<Position>(positionDTO);
                await _dbPosition.UpdateAsync(model);

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
