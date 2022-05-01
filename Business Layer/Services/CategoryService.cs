using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.SelectAll().
                Select(x => new Category { id = x.id, Description = x.Description, Name = x.Name });
        }
        public Category GetCategoryById(int Id) => categoryRepository.SelectOneById(Id);
    }
}
