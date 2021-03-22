using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(36)]
        public string DisplayName { get; set; }

    }
}
