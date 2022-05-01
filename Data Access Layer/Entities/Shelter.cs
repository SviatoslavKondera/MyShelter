using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Shelter : BaseEntity
    {
        
        public string ShelterName { get; set; }
        public string ShelterShortDescription { get; set; }
        public string ShelterLongDescription { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PeopleCount { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}