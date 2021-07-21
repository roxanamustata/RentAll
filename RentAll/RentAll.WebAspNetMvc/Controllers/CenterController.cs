using Microsoft.AspNetCore.Mvc;
using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.WebAspNetMvc.Controllers
{
    public class CenterController : Controller
    {
        private readonly ICenterRepository _centerRepository;

        public CenterController(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }


        public ViewResult List()
        {
            return View(_centerRepository.GetCentersAsync().Result);
        }
    }
}
