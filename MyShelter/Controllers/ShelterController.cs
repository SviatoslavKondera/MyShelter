
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
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyShelter.ViewModels;
using Microsoft.Extensions.Hosting.Internal;

namespace MyShelter.Controllers
{
    public class ShelterController : Controller
    {
        private readonly ILogger<ShelterController> logger;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IShelterService shelterService;
        private readonly ICategoryService categoryService;

        public ShelterController(ILogger<ShelterController> logger, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IShelterService shelterService, ICategoryService categoryService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.shelterService = shelterService;
            this.categoryService = categoryService;
            this.hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult GetAllShelters()
        {
            var shelters = shelterService.GetAllShelters();
            return View(shelters);
        }

        public IActionResult CreateShelter()
        {
            ViewData["AvailebleCategories"] = categoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateShelter(ShelterViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Image != null)
                { 
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Shelter newShelter = new Shelter
                {
                    ShelterName = model.ShelterName,
                    ShelterShortDescription = model.ShelterShortDescription,
                    ShelterLongDescription = model.ShelterLongDescription,
                    Image = uniqueFileName,
                    City = model.City,
                    Street = model.Street,
                    PeopleCount = model.PeopleCount,
                    CategoryId = model.CategoryId,
                    Category = categoryService.GetCategoryById(model.CategoryId)

                };

                shelterService.AddNewShelter(newShelter);
            }

            return RedirectToAction(nameof(GetAllShelters));
        }

        

    }
}