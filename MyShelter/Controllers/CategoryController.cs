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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace LNU_Test_Portal.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly IConfiguration configuration;
        private readonly ICategoryService categoryService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public CourseController(ILogger<CourseController> logger, IConfiguration configuration, ICategoryService categoryService, SignInManager<ApplicationUser> signInManager)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.categoryService = categoryService;
            this.signInManager = signInManager;
        }

        public IActionResult GetAllCategories()
        {

            var categories = categoryService.GetAllCategories();
            logger.LogInformation("Show all categories");

            return View(categories);
        }


        public IActionResult Create()
        {
            var model = new Category();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("name,description")] Category category)
        {
            categoryService.AddNewCategory(category);
            return RedirectToAction(nameof(GetAllCategories));
        }


        public IActionResult Edit(int Id)
        {
            try
            {
                Category category = categoryService.GetCategoryById(Id);
                return View(category);
            }
            catch
            {
                logger.LogError("Error occured when trying to edit category");
                return RedirectToAction(nameof(GetAllCategories));

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,name,description")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryService.UpdateCategory(category);
                    return RedirectToAction(nameof(GetAllCategories));
                }
            }
            catch
            {
                logger.LogError("Error occured when trying to edit coure");
                return RedirectToAction(nameof(GetAllCategories));
            }
            return View(category);
        }


        public IActionResult Delete(int Id)
        {
            try
            {
                Category category = categoryService.GetCategoryById(Id);
                return View(category);
            }
            catch
            {
                logger.LogError("Error occured when trying to delete category");
                return RedirectToAction(nameof(GetAllCategories));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                Category category = new Category { id = Id };
                categoryService.DeleteCategory(category);
                return RedirectToAction(nameof(GetAllCategories));
            }
            catch
            {
                logger.LogError("Error occured when trying to delete category");
                return RedirectToAction(nameof(GetAllCategories));
            }
        }

    }
}