using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Category : BaseEntity
    {
        public string name { get; set; }
        public string description { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public virtual IEnumerable<Shelter> Shelters { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}