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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MyShelter.ViewModels;

namespace LNU_Test_Portal.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> logger;
        private readonly IConfiguration configuration;
        private readonly ICategoryService categoryService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;

        public CategoryController(ILogger<CategoryController> logger, IConfiguration configuration,
            ICategoryService categoryService, SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.categoryService = categoryService;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult GetAllCategories(string searching, bool isActive)
        {

            var categories = categoryService.GetAllCategories();
            if (!String.IsNullOrEmpty(searching))
            {
                categories = categories.Where(s => s.name.ToLower().Contains(searching.ToLower()));
            }

            if (isActive == true)
            {
                categories = categories.Where(s => s.UserId==userManager.GetUserId(User));
            }

            logger.LogInformation("User " + User.Identity.Name + " get all categories");

            return View(categories);
        }


        
        public IActionResult Create()
        {
            logger.LogInformation("User " + User.Identity.Name + " trying to create new Category");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel model)
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

                Category newCategory = new Category
                {
                    description = model.description,
                    name = model.name,
                    Image = uniqueFileName,
                    UserId = userManager.GetUserId(User)
                    
                };


                
                categoryService.AddNewCategory(newCategory);
                logger.LogInformation("User " + User.Identity.Name + " created new category with id=" + newCategory.id);
                return RedirectToAction(nameof(GetAllCategories));
            }
            logger.LogError("Error occurred when User " + User.Identity.Name + " created new category");
            return View(model);    
        }


        
        public IActionResult Edit(int Id)
        {
            try
            {
                Category category = categoryService.GetCategoryById(Id);
                CategoryEditViewModel newCategoryViewModel = new CategoryEditViewModel
                {
                    Id = category.id,
                    name = category.name,
                    description = category.description,
                    ExistingImage = category.Image
                };
                logger.LogInformation("User trying to edit City Object with Id=" + category.id);

                return View(newCategoryViewModel);
            }
            catch(Exception ex)
            {
                logger.LogError("Error occured when User" + User.Identity.Name +" called Edit get method.Error description: "+ex.Message);
                return RedirectToAction(nameof(GetAllCategories));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                Category cat = categoryService.GetCategoryById(model.Id);
                cat.name = model.name;
                cat.description = model.description;

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
                    cat.Image = uniqueFileName;
                }

                categoryService.UpdateCategory(cat);
                return RedirectToAction(nameof(GetAllCategories));
            }
            logger.LogError("Error occured when User" + User.Identity.Name + " called Edit post method");
            return View(model);
        }


        public IActionResult Delete(int Id)
        {
            try
            {
                Category category = categoryService.GetCategoryById(Id);
                logger.LogInformation("User trying to delete Category with Id=" + Id);
                return View(category);
            }
            catch (Exception ex)
            {
                logger.LogError("Error has occurred when user :" + User.Identity.Name + " trying to delete get method Category with Id=" + Id + " Error description:" + ex.Message);
                return RedirectToAction(nameof(GetAllCategories));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {

            Category category = categoryService.GetCategoryById(Id);
            if (category.Image != null)
            {
                var ImgPath = Path.Combine(hostingEnvironment.WebRootPath, "Images", category.Image);
                if (System.IO.File.Exists(ImgPath))
                    System.IO.File.Delete(ImgPath);
            }
            
            categoryService.DeleteCategory(category);
            logger.LogInformation("User "+User.Identity.Name +" delete Category with Id=" + Id + " successfully");
            return RedirectToAction(nameof(GetAllCategories));
            
        }

    }
}