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

        public string name { get; set; }
        public string description { get; set; }
        public IFormFile Image { get; set; }
        public virtual IEnumerable<Shelter> Shelters { get; set; }
    }
}