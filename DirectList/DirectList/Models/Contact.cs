using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string FName { get; set; }
        [MaxLength(50), Required]
        public string LName { get; set; }
        [MaxLength(100), Required]
        public string Subject { get; set; }
        [MaxLength(2000), Required]
        public string Text { get; set; }
        [MaxLength(50), Required]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }






    }
}
