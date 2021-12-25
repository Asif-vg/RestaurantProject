using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Models
{
    public class RestaurantComment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(250)]
        public string Subject { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        






    }
}
