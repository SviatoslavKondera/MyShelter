using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Entities
{
    public class Category : BaseEntity
    {
        public string name { get; set; }
        public string description { get; set; }
        public virtual IEnumerable<Shelter> Shelters { get; set; }
    }
}