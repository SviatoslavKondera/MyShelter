using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer.Services.ViewModels;

namespace Business_Layer.Services
{
    public class ShelterService : IShelterService
    {
        private readonly IRepository<Shelter> shelterRepository;
        private readonly IRepository<Category> categoryRepository;

        public ShelterService(IRepository<Shelter> shelterRepository, IRepository<Category> categoryRepository)
        {
            this.shelterRepository = shelterRepository;
            this.categoryRepository = categoryRepository;
        }

        public void AddNewShelter(Shelter shelter)
        {
            shelterRepository.Insert(shelter);
        }

        public void DeleteShelter(Shelter shelter)
        {
            shelterRepository.Delete(shelter);
        }

        public IEnumerable<Shelter> GetAllShelters()
        {
            return shelterRepository.SelectAll().Select(x => new Shelter
            {
                id = x.id,
                ShelterName = x.ShelterName,
                ShelterShortDescription = x.ShelterShortDescription,
                ShelterLongDescription = x.ShelterLongDescription,
                Image = x.Image,
                City = x.City,
                Street = x.Street,
                PeopleCount = x.PeopleCount,
                CategoryId = categoryRepository.SelectOneById(x.CategoryId).id,
                Category = categoryRepository.SelectOneById(x.CategoryId)
                
            }) ;
        }

        public Shelter GetShelterById(int Id)
        {
            return shelterRepository.SelectOneById(Id);
        }

        public void Update(Shelter shelt)
        {
            shelterRepository.Update(shelt);
        }
    }
}
