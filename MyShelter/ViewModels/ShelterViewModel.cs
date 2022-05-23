using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MyShelter.ViewModels
{
    public class ShelterViewModel 
    {
        [Required(ErrorMessage = "���� ����'������")]
        public string ShelterName { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public string ShelterShortDescription { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public string ShelterLongDescription { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public string City { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public string Street { get; set; }
        public int PeopleCount { get; set; }
       
        public Category Category { get; set; }
       
        public int CategoryId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}