using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyShelter.ViewModels
{
    public class ShelterViewModel 
    {
        [Required(ErrorMessage = "���� ����'������")]
        [StringLength(140)]
        public string ShelterName { get; set; }
        [Required(ErrorMessage = "���� ����'������")]


        [StringLength(190)]
        public string ShelterShortDescription { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public string ShelterLongDescription { get; set; }
        
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "���� ����'������")]

        [StringLength(33)]
        public string City { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        [StringLength(33)]
        public string Street { get; set; }
        public int PeopleCount { get; set; }
       
        public Category Category { get; set; }
       
        public int CategoryId { get; set; }
        public SelectList CategoryList { get; set; }


        [Required(ErrorMessage = "���� ����'������")]
        public string CategoryStr { get; set; }



        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}