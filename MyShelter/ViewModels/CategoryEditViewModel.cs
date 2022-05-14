using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MyShelter.ViewModels
{
    public class CategoryEditViewModel :CategoryViewModel
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
    }
}