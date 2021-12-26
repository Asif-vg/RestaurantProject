using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Models
{
    public class DreamPlan
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(250)]
        public string SubTitle { get; set; }
        [MaxLength(500)]
        public string SubContent { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        public DateTime CreatedDate { get; set; }





    }
}
