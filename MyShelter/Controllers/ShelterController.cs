
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using BLL.Services;
using BLL.Services.Interfaces;
using Data_Access_Layer.Entities;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyShelter.ViewModels;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyShelter.Controllers
{
    [AllowAnonymous]
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
        
        [AllowAnonymous]
        public IActionResult GetAllShelters(string SelectOption, string searching, string City)
        {
            var shelters = shelterService.GetAllShelters();
            ViewData["AvailebleCategories"] = categoryService.GetAllCategories();

            if (!String.IsNullOrEmpty(searching))
            {
                shelters = shelters.Where(s => s.ShelterName.Contains(searching));
            }
            if (!String.IsNullOrEmpty(City))
            {
                shelters = shelters.Where(s => s.City.Contains(City));
            }
            if (!String.IsNullOrEmpty(SelectOption))
            {
                shelters = shelters.Where(s => s.Category.name.Contains(SelectOption));
            }
            return View(shelters.ToList());
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


        public IActionResult EditShelter(int Id)
        {
            try
            {
                Shelter shelter = shelterService.GetShelterById(Id);
                ShelterEditViewModel newShelterViewModel = new ShelterEditViewModel
                {
                    Id = shelter.id,
                    ShelterName = shelter.ShelterName,
                    ShelterShortDescription = shelter.ShelterShortDescription,
                    ShelterLongDescription = shelter.ShelterLongDescription,
                    City = shelter.City,
                    Street = shelter.Street,
                    PeopleCount = shelter.PeopleCount,
                    CategoryId = shelter.CategoryId,
                    Category = categoryService.GetCategoryById(shelter.CategoryId),
                    ExistingImage = shelter.Image 
                };

                ViewData["AvailebleCategories"] = categoryService.GetAllCategories();
                return View(newShelterViewModel);
            }
            catch
            {
                return RedirectToAction(nameof(GetAllShelters));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditShelter(ShelterEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                Shelter shelt = shelterService.GetShelterById(model.Id);
                shelt.ShelterName = model.ShelterName;
                shelt.ShelterShortDescription = model.ShelterShortDescription;
                shelt.ShelterLongDescription = model.ShelterLongDescription;
                shelt.City = model.City;
                shelt.Street = model.Street;
                shelt.PeopleCount = model.PeopleCount;
                shelt.CategoryId = model.CategoryId;
                shelt.Category = model.Category;

                if (model.Image != null)
                {
                  
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "Images", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    string uniqueFileName = null;

                    if (model.Image != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.Image.CopyTo(fileStream);
                        }
                    }
                    shelt.Image = uniqueFileName;
                }

                shelterService.Update(shelt);
                
            }

            return RedirectToAction(nameof(GetAllShelters));
        }

        public IActionResult DeleteShelter(int Id)
        {
            try
            {
                Shelter shelter = shelterService.GetShelterById(Id);
                return View(shelter);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllShelters));
            }
        }

        [HttpPost, ActionName("DeleteShelter")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                Shelter shelter = shelterService.GetShelterById(Id);
                var ImgPath = Path.Combine(hostingEnvironment.WebRootPath, "Images", shelter.Image);
                if (System.IO.File.Exists(ImgPath))
                    System.IO.File.Delete(ImgPath);
                shelterService.DeleteShelter(shelter);
                return RedirectToAction(nameof(GetAllShelters));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllShelters));
            }
        }



        public IActionResult ShelterDetails(int Id)
        {
            try
            {
                Shelter shelter = shelterService.GetShelterById(Id);
                ShelterEditViewModel newShelterViewModel = new ShelterEditViewModel
                {
                    Id = shelter.id,
                    ShelterName = shelter.ShelterName,
                    ShelterShortDescription = shelter.ShelterShortDescription,
                    ShelterLongDescription = shelter.ShelterLongDescription,
                    City = shelter.City,
                    Street = shelter.Street,
                    PeopleCount = shelter.PeopleCount,
                    CategoryId = shelter.CategoryId,
                    Category = categoryService.GetCategoryById(shelter.CategoryId),
                    ExistingImage = shelter.Image
                };

                ViewData["AvailebleCategories"] = categoryService.GetAllCategories();
                return View(newShelterViewModel);
            }
            catch
            {
                return RedirectToAction(nameof(GetAllShelters));
            }

        }


    }
}