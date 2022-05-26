
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
using Microsoft.AspNetCore.Identity;

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
        private readonly UserManager<ApplicationUser> userManager;

        public ShelterController(ILogger<ShelterController> logger, IHostingEnvironment hostingEnvironment, IConfiguration configuration,
            IShelterService shelterService, ICategoryService categoryService, UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.shelterService = shelterService;
            this.categoryService = categoryService;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }
        

        //2 факторна
        // гугл мапс
        [AllowAnonymous]
        public IActionResult GetAllShelters(string SelectOption, string searching, string City,bool isActive)
        {
            var shelters = shelterService.GetAllShelters();
            ViewData["AvailebleCategories"] = categoryService.GetAllCategories();

            if (!String.IsNullOrEmpty(searching))
            {
                shelters = shelters.Where(s => s.ShelterName.ToLower().Contains(searching.ToLower()));
            }
            if (!String.IsNullOrEmpty(City))
            {
                shelters = shelters.Where(s => s.City.ToLower().Contains(City.ToLower()));
            }
            if (!String.IsNullOrEmpty(SelectOption))
            {
                shelters = shelters.Where(s => s.Category.name.Contains(SelectOption));
            }
            if (isActive == true)
            {
                shelters = shelters.Where(s => s.UserId == userManager.GetUserId(User));
            }

            logger.LogInformation("Getting All City Objects");
            return View(shelters.ToList());
        }

        public IActionResult CreateShelter()
        {
            ShelterViewModel model = new ShelterViewModel();
            model.CategoryList = AvailableCategories();
            logger.LogInformation("User trying to add new City Object");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateShelter(ShelterViewModel model)
        {

            model.CategoryList = AvailableCategories();
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
                    CategoryId = Convert.ToInt32(model.CategoryStr),
                    Category = categoryService.GetCategoryById(model.CategoryId),
                    UserId = userManager.GetUserId(User),
                    Longitude = model.Longitude,
                    Latitude = model.Latitude
                };

                shelterService.AddNewShelter(newShelter);
                return RedirectToAction(nameof(GetAllShelters));
            }
            logger.LogInformation("City Object added successfully");
            return View(model);   
        }


        public IActionResult EditShelter(int Id)
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
                ExistingImage = shelter.Image,
                CategoryStr = shelter.CategoryId.ToString(),
                Latitude = shelter.Latitude,
                Longitude = shelter.Longitude

            };
            newShelterViewModel.CategoryList = AvailableCategories();
            logger.LogInformation("User trying to edit City Object with Id="+shelter.id);
            return View(newShelterViewModel);
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
                shelt.CategoryId = Convert.ToInt32(model.CategoryStr);
                shelt.Category = categoryService.GetCategoryById(Convert.ToInt32(model.CategoryStr));
                shelt.Longitude = model.Longitude;
                shelt.Latitude = model.Latitude;

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
                logger.LogInformation("User edit City Object with Id=" + shelt.id+"successfully.");
                return RedirectToAction(nameof(GetAllShelters));

            }

            return View(model);

            
        }

        public IActionResult DeleteShelter(int Id)
        {
            try
            {
                Shelter shelter = shelterService.GetShelterById(Id);
                logger.LogInformation("User trying to delete City Object with Id=" + Id);
                return View(shelter);
            }
            catch (Exception ex)
            {
                logger.LogError("Error has occurred when user :" + User.Identity.Name + " trying to delete get City Object with Id=" + Id + " Error description:" + ex.Message);
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
                if (shelter.Image != null)
                {
                    var ImgPath = Path.Combine(hostingEnvironment.WebRootPath, "Images", shelter.Image);
                    if (System.IO.File.Exists(ImgPath))
                        System.IO.File.Delete(ImgPath);
                }
                    
                shelterService.DeleteShelter(shelter);
                logger.LogInformation("User delete City Object with Id=" + Id + " successfully");
                return RedirectToAction(nameof(GetAllShelters));
            }
            catch (Exception ex)
            {
                logger.LogError("Error has occurred when user :" + User.Identity.Name + " trying to delete get City Object with Id=" + Id + " Error description:" + ex.Message);
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
                    ExistingImage = shelter.Image,
                    Latitude = shelter.Latitude,
                    Longitude = shelter.Longitude
                };

                ViewData["AvailebleCategories"] = categoryService.GetAllCategories();
                logger.LogInformation("User " + User.Identity.Name + " get details for City Object with Id=" + Id + " successfully");
                return View(newShelterViewModel);
            }
            catch(Exception ex)
            {
                logger.LogError("Error has occurred when user :" + User.Identity.Name + " trying to get details for City Object with Id=" + Id + " Error description:" + ex.Message);
                return RedirectToAction(nameof(GetAllShelters));
            }

        }

        private SelectList AvailableCategories()
        {
            List<SelectListItem> categ = new List<SelectListItem>();
            var categories = categoryService.GetAllCategories();
            categ.Add(new SelectListItem { Text = "Оберіть Категорію", Value = "" });
            foreach (var item in categories)
            {
                categ.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
            }

            SelectList items = new SelectList(categ, "Value", "Text");
            return items;
        }


    }
}