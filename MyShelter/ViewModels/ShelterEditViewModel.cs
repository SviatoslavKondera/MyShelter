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
    public class ShelterEditViewModel :ShelterViewModel
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
    }
}