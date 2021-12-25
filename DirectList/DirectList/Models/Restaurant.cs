using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [Column("ntext")]
        public string About { get; set; }
        [MaxLength(30)]
        public string Phone1 { get; set; }
        [MaxLength(30)]
        public string Phone2 { get; set; }
        [MaxLength(30)]
        public string Phone3 { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(500)]
        public string AddressLocation { get; set; }
        [MaxLength(2000)]
        public string LocationNote { get; set; }


        [NotMapped]
        public List<int> TagToRestaurantId { get; set; }

        [NotMapped]
        public List<int> MenuToRestaurantId { get; set; }

        [NotMapped]
        public List<int> FeatureToRestaurantId { get; set; }

        public List<RestaurantImage> RestaurantImages { get; set; }
        public List<RestaurantComment> RestaurantComments { get; set; }
        public List<TagToRestaurant> TagToRestaurants { get; set; }
        public List<FeatureToRestaurant> FeatureToRestaurants { get; set; }
        public List<MenuToRestaurant> MenuToRestaurants { get; set; }
        public List<Book> Books { get; set; }







    }
}
