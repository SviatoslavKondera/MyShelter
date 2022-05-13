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
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MyShelter.ViewModels;

namespace LNU_Test_Portal.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> logger;
        private readonly IConfiguration configuration;
        private readonly ICategoryService categoryService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public CategoryController(ILogger<CategoryController> logger, IConfiguration configuration, ICategoryService categoryService, SignInManager<ApplicationUser> signInManager, IHostingEnvironment hostingEnvironment)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.categoryService = categoryService;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult GetAllCategories()
        {

            var categories = categoryService.GetAllCategories();
            logger.LogInformation("Show all categories");

            return View(categories);
        }


        public IActionResult Create()
        {
            
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
                    Image = uniqueFileName
                };

                categoryService.AddNewCategory(newCategory);
            }

            return RedirectToAction(nameof(GetAllCategories));
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

                return View(newCategoryViewModel);
            }
            catch
            {
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

            }

            return RedirectToAction(nameof(GetAllCategories));
        }


        public IActionResult Delete(int Id)
        {
            try
            {
                Category category = categoryService.GetCategoryById(Id);
                return View(category);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllCategories));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                Category category = categoryService.GetCategoryById(Id);
                var ImgPath = Path.Combine(hostingEnvironment.WebRootPath, "Images", category.Image);
                if (System.IO.File.Exists(ImgPath))
                    System.IO.File.Delete(ImgPath);
                categoryService.DeleteCategory(category);
                return RedirectToAction(nameof(GetAllCategories));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllCategories));
            }
        }

    }
}