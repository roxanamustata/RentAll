using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAll.Domain.Interfaces;
using RentAll.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;

        }

   
        [HttpGet]

        public async Task<ActionResult<IEnumerable<GetCompanyDto>>> ListCompanies()
        {
            try
            {
                var companies = await _companyService.GetCompaniesAsync();
                var companyDtos = _mapper.Map<IEnumerable<GetCompanyDto>>(companies);

                return Ok(companyDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
