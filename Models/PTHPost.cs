using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Models
{
    public class PTHPost
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(30)]
        [Display(Name = "Author")]
        public string OP { get; set; }
        public DateTime PostTime { get; set; }
        public string PostFileName { get; set; }
        public int PTHThreadId { get; set; }


        public PTHThread PTHThread { get; set; }

    }
}
