using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penetration_Testing_Hub.Models
{
    public class PTHThread
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public DateTime CreatTime { get; set; }
        public DateTime ModifyTime { get; set; }
        [StringLength(30)]
        [Display(Name = "Author")]
        public string OP { get; set; }
        public int ThreadCategory { get; set; }

        public ICollection<PTHPost> PTHPosts { get; set; }
    }
}
