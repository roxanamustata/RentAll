using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService _centerService;
        private readonly ICenterRepository _centerRepository;


        //private readonly ILogger<CenterController> _logger;

        public CenterController(ICenterService centerService, ICenterRepository centerRepository)
        {
            _centerService = centerService;
            _centerRepository = centerRepository;
        }

        [HttpGet("centers")]
        public IEnumerable<Center> Get()
        {
            return _centerRepository.GetCenters();
        }
    }
}
