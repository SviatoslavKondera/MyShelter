
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
        private readonly ICategoryService categoryService;

        public ShelterController(ILogger<ShelterController> logger, IConfiguration configuration, IShelterService shelterService, ICategoryService categoryService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.shelterService = shelterService;
            this.categoryService = categoryService;
        }
        
        public IActionResult GetAllShelters()
        {
            var shelters = shelterService.GetAllShelters();
            return View(shelters);
        }

        public IActionResult CreateShelter()
        {
            var shelter = new Shelter();
            ViewData["AvailebleCategories"] = categoryService.GetAllCategories();
            return View(shelter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateShelter([Bind("ShelterName,ShelterShortDescription,ShelterLongDescriptionCity,Image,City,Street,PeopleCount,CategoryId")] Shelter shelter)
        {
            shelter.Category = categoryService.GetCategoryById(shelter.CategoryId);
            shelterService.AddNewShelter(shelter);
            return RedirectToAction(nameof(GetAllShelters));
        }

    }
}