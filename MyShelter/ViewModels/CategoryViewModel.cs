using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MyShelter.ViewModels
{
    public class CategoryViewModel 
    {

        [Required(ErrorMessage = "���� ����'������")]
        public string name { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public string description { get; set; }
        [Required(ErrorMessage = "���� ����'������")]
        public IFormFile Image { get; set; }
        public virtual IEnumerable<Shelter> Shelters { get; set; }


        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}