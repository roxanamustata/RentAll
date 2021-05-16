using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentAll.Domain;
using RentAll.Domain.DTOs;
using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService _centerService;
        private readonly IMapper _mapper;

        public CenterController(ICenterService centerService, IMapper mapper)
        {
            _centerService = centerService;
            _mapper = mapper;

        }

        [HttpGet]

        public async Task<IActionResult> List()
        {
            try
            {
                var centers = await _centerService.GetCenters();
                var centerDtos = _mapper.Map<IEnumerable<CenterDto>>(centers);

                return Ok(centerDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCenterById(int id)
        {
            var center = await _centerService.GetCenterById(id);
            var centerDto = _mapper.Map<CenterDto>(center);

            try
            {
                return Ok(centerDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCenter(CenterDto centerDto)
        {


            try
            {
                if (centerDto == null)
                    return BadRequest();

                var center = _mapper.Map<Center>(centerDto);
                var createdCenter = await _centerService.CreateCenter(center);

                return CreatedAtAction(nameof(GetCenterById),
                    new { id = createdCenter.Id }, createdCenter);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new center record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCenter(int id, CenterDto centerDto)
        {
            try
            {


                var centerToUpdate = await _centerService.GetCenterById(id);

                if (centerToUpdate == null)
                    return NotFound($"Center with Id = {id} not found");
                centerToUpdate = _mapper.Map<Center>(centerDto);

                await _centerService.UpdateCenter(centerToUpdate);
                return Ok($"Center with Id = {id} was updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]

        public void Delete(int id)
        {
            try
            {
                _centerService.DeleteCenter(id);
            }

            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                     "Error deleting data");
            }
        }

    }
}