using BLL.Services;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class CategoryTests
    {


        private readonly CategoryService categoryService;
        private readonly Mock<IRepository<Category>> categoryRepo;

        public CategoryTests()
        {
            categoryRepo = new Mock<IRepository<Category>>();
            categoryService = new CategoryService(categoryRepo.Object);
        }


        [Test]
        public void GetCategoryByIdTestReturnCategory()
        {

            //Arrange
            var categories = new List<Category>() { new Category { id = 1 }, new Category { id = 2 }, new Category { id = 3 } };
            var FirstCategory = categories.First();
            var expected = FirstCategory;

            //Act
            categoryRepo.Setup(x => x.SelectOneById(FirstCategory.id)).Returns(FirstCategory);
            var ReturnedCategory = categoryService.GetCategoryById(FirstCategory.id);
            var actual = ReturnedCategory;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCategoryByIdTestReturnNull()
        {

            //Arrange
            var categories = new List<Category>() { new Category { id = 12 }, new Category { id = 32 } };
            int categoryId = -2;
            var FirstCategory = new Category();

            //Act
            categoryRepo.Setup(x => x.SelectOneById(categoryId)).Returns(FirstCategory);
            var ReturnedCategory = categoryService.GetCategoryById(FirstCategory.id);
            var actual = ReturnedCategory;

            //Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void GetAllCategories()
        {

            //Arrange
            var categories = new List<Category>() { new Category { id = 12, name = "categ1" }, new Category { id = 32, name = "categ2" } };
            var expected = categories.Count();
          

            //Act
            categoryRepo.Setup(x => x.SelectAll()).Returns(categories);
            var ReturnedCategory = categoryService.GetAllCategories();
            var actual = ReturnedCategory.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }



    }
}