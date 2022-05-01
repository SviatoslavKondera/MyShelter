
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Business_Layer.Services;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;

namespace MyShelter.Controllers
{
    public class ShelterController : Controller
    {
        private readonly ILogger<ShelterController> logger;
        private readonly IConfiguration configuration;
        private readonly IShelterService shelterService;

        public ShelterController(ILogger<ShelterController> logger, IConfiguration configuration, IShelterService shelterService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.shelterService = shelterService;
        }
        
        public IActionResult GetAllShelters()
        {
            var shelters = shelterService.GetAllShelters();
            logger.LogInformation("Show all shelters");
            return View(shelters);
        }

        public IActionResult CreateShelter()
        {
            var model = new Shelter();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateShelter([Bind("ShelterName,City,Street,PeopleCount,ShelterShortDescription")] Shelter shelter)
        {
            shelterService.AddNewShelter(shelter);
            return RedirectToAction(nameof(GetAllShelters));
        }

    }
}