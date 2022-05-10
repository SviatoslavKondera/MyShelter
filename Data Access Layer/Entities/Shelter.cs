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
        [Required]
        public string ShelterName { get; set; }
        [Required]
        public string ShelterShortDescription { get; set; }
        public string ShelterLongDescription { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        public int PeopleCount { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}