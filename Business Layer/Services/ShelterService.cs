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
    public class ShelterService : IShelterService
    {
        private readonly IRepository<Shelter> shelterRepository;
        public ShelterService(IRepository<Shelter> shelterRepository)
        {
            this.shelterRepository = shelterRepository;
        }

        public IEnumerable<Shelter> GetAllShelters()
        {
            throw new NotImplementedException();
        }
    }
}
