using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Models
{
    public class StageTechnique_Reconnaissance_Tool
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public DateTime CreatTime { get; set; }
        public DateTime ModifyTime { get; set; }
        [StringLength(30)]
        [Display(Name = "User")]
        public string OP { get; set; }

        public ICollection<StageTechnique_Reconnaissance_Tool_Post> StageTechnique_Reconnaissance_Tool_Posts { get; set; }
    }
}
