using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Models
{
    public class StageTechnique_Reconnaissance_Tool_Post
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(30)]
        [Display(Name = "User")]
        public string OP { get; set; }
        public DateTime PostTime { get; set; }
        public string PostFileName { get; set; }
        public int StageTechnique_Reconnaissance_ToolId { get; set; }


        public StageTechnique_Reconnaissance_Tool StageTechnique_Reconnaissance_Tool { get; set; }

    }
}
