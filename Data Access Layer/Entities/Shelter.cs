using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Entities
{
    public class Shelter : BaseEntity
    {
        
        public string ShelterName { get; set; }
        public string ShelterShortDescription { get; set; }
        public string ShelterLongDescription { get; set; }
        public string Img { get; set; }
        public string City { get; set; }
        public int PeopleCount { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}