using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

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
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Latitude { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}