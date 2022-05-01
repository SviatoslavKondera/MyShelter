using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IShelterService
    {
        IEnumerable<Shelter> GetAllShelters();
        void AddNewShelter(Shelter shelter);
        Shelter GetShelterById(int Id);
        void Update(Shelter shelt);
        void DeleteShelter(Shelter shelter);
    }
}
