using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string CustomerID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public string Province { get; set; }
        [Required]
        [Display(Name="Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Total { get; set; }
    }
}
