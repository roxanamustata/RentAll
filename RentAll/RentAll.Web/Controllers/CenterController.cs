using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RentAll.Domain;
using RentAll.Domain.DTOs;
using RentAll.Domain.Interfaces;
using RentAll.Web.DTOs;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace RentAll.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService _centerService;
        private readonly IMapper _mapper;

        public CenterController(ICenterService centerService, IMapper mapper)
        {
            _centerService = centerService;
            _mapper = mapper;

        }

        #region CENTERS

        [HttpGet]

        public async Task<IActionResult> ListCenters()
        {
            try
            {
                var centers = await _centerService.GetCentersAsync();
                var centerDtos = _mapper.Map<IEnumerable<GetCenterDto>>(centers);

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
            var center = await _centerService.GetCenterByIdAsync(id);
            var centerDto = _mapper.Map<GetCenterDto>(center);

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
        public async Task<IActionResult> CreateCenter(CreateCenterDto centerDto)
        {

            try
            {
                if (centerDto == null)
                    return BadRequest();

                var center = _mapper.Map<Center>(centerDto);
                var createdCenter = await _centerService.CreateCenterAsync(center);

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
        public async Task<IActionResult> UpdateCenter(int id, UpdateCenterDto centerDto)
        {
            try
            {


                var centerToUpdate = await _centerService.GetCenterByIdAsync(id);

                if (centerToUpdate == null)
                    return NotFound($"Center with Id = {id} not found");
                centerToUpdate = _mapper.Map(centerDto, centerToUpdate);

                await _centerService.UpdateCenterAsync(centerToUpdate);
                return Ok($"Center with Id = {id} was updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteCenter(int id)
        {
            try
            {
                await _centerService.DeleteCenterAsync(id);
                return Ok($"Center with Id = {id} was deleted");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error deleting data");
            }
        }
        #endregion

        #region UNITS

        [HttpGet]
        [Route("{id:int}/units")]

        public async Task<IActionResult> ListUnitsInCenter(int id)
        {
            try
            {
                var units = await _centerService.GetUnitsInCenterAsync(id);
                var unitDtos = _mapper.Map<IEnumerable<GetUnitDto>>(units);

                return Ok(unitDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpGet]
        [Route("{id:int}/units/{unitId}")]
        public async Task<IActionResult> GetUnitById(int id, int unitId)
        {
            var unit = await _centerService.GetUnitByIdAsync(id, unitId);

            if (unit == null)
                return NotFound($"Unit with Id = {unitId} not found");


            var unitDto = _mapper.Map<GetUnitDto>(unit);

            try
            {
                return Ok(unitDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:int}/units/{unitCode}/code")]
        public async Task<IActionResult> GetUnitByCode(int id, string unitCode)
        {
            var unit = await _centerService.GetUnitFromCenterByUnitCodeAsync(id, unitCode);

            if (unit == null)
                return NotFound($"Unit with code = {unitCode} not found");

            var unitDto = _mapper.Map<GetUnitDto>(unit);

            try
            {
                return Ok(unitDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("{id:int}/units")]
        public async Task<IActionResult> CreateUnitInCenter(int id, CreateUnitDto unitDto)
        {

            try
            {
                if (unitDto == null)
                    return BadRequest();

                var unit = _mapper.Map<Unit>(unitDto);
                var createdUnit = await _centerService.CreateUnitInCenterAsync(id, unit);

                return CreatedAtAction(nameof(GetUnitById),
                    new { id = createdUnit.Id }, createdUnit);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new unit record");
            }
        }

        [HttpPut]
        [Route("{id:int}/units/{unitId:int}")]
        public async Task<IActionResult> UpdateUnitInCenter(int id, int unitId, UpdateUnitDto unitDto)
        {
            try
            {
                var unitToUpdate = await _centerService.GetUnitByIdAsync(id, unitId);

                if (unitToUpdate == null)
                    return NotFound($"Center with Id = {id} not found");
                unitToUpdate = _mapper.Map(unitDto, unitToUpdate);

                await _centerService.UpdateUnitAsync(id, unitToUpdate);
                return Ok($"Unit with Id = {unitId} was updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete]
        [Route("{id:int}/units/{unitId:int}")]
        public async Task<IActionResult> DeleteUnitById(int id, int unitId)
        {
            try
            {
                await _centerService.DeleteUnitAsync(id, unitId);
                return Ok($"Unit with Id = {unitId} was deleted");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error deleting data");
            }
        }
        #endregion

        #region LEASES

        [HttpGet]
        [Route("{id:int}/units/leases/{leaseId}")]
        public async Task<IActionResult> GetLeaseById(int id, int leaseId)
        {
            var lease = await _centerService.GetLeaseByIdAsync(id, leaseId);

            if (lease == null)
                return NotFound($"Unit with Id = {leaseId} not found");

            var leaseDto = _mapper.Map<GetLeaseDto>(lease);

            try
            {
                return Ok(leaseDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:int}/units/{unitCode}/leases/valid")]
        public async Task<IActionResult> GetValidLeaseByUnitCode(int id, string unitCode)
        {
            var lease = await _centerService.GetValidLeaseByUnitCodeAsync(id, unitCode);

            if (lease == null)
                return NotFound($"No valid lease was found for unit with code = {unitCode}");

            var leaseDto = _mapper.Map<GetLeaseDto>(lease);

            try
            {
                return Ok(leaseDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:int}/units/leases")]
        public async Task<IActionResult> ListLeasesInCenter(int id)
        {
            try
            {
                var leases = await _centerService.GetLeasesInCenterAsync(id);
                var leaseDtos = _mapper.Map<IEnumerable<GetLeaseDto>>(leases);

                return Ok(leaseDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("{id:int}/units/{unitId:int}/leases")]
        public async Task<IActionResult> CreateLeaseInCenter(int id, int unitId, CreateLeaseDto leaseDto)
        {

            try
            {
                if (leaseDto == null)
                    return BadRequest();

                var lease = _mapper.Map<Lease>(leaseDto);

                Lease createdLease = await _centerService.CreateLeaseInCenterAsync(id, unitId, lease);

                return CreatedAtAction(nameof(GetLeaseById),
                    new { id = createdLease.Id }, createdLease);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new lease record");
            }
        }

        [HttpDelete]
        [Route("{id:int}/units/leases/{leaseId:int}")]
        public async Task<IActionResult> DeleteLeaseById(int id, int leaseId)
        {
            try
            {
                await _centerService.DeleteLeaseAsync(id, leaseId);
                return Ok($"Lease with Id = {leaseId} was deleted");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error deleting data");
            }
        }

        [HttpPut]
        [Route("{id:int}/units/leases/{leaseId:int}")]
        public async Task<IActionResult> UpdateLeaseInCenter(int id, int leaseId, UpdateLeaseDto leaseDto)
        {
            try
            {
                var leaseToUpdate = await _centerService.GetLeaseByIdAsync(id, leaseId);

                if (leaseToUpdate == null)
                    return NotFound($"Lease with Id = {id} not found");
                
                leaseToUpdate = _mapper.Map(leaseDto, leaseToUpdate);

                await _centerService.UpdateLeaseAsync(id, leaseToUpdate);
                return Ok($"Lease with Id = {leaseId} was updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        #endregion


        #region COMPANIES

        #endregion


    }
}