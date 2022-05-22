using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public virtual IEnumerable<Category> Categories { get; set; }
        public virtual IEnumerable<Shelter> Shelters { get; set; }
    }
}
