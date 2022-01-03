using DirectList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.ViewModels
{
    public class VmHome :VmLayout
    {
        public List<Restaurant> Restaurants { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<DreamPlan> DreamPlans { get; set; }
        public List<string> Cart { get; set; }
        public List<string> AddToCart { get; set; }

        public VmSearch Search { get; set; }


    }
}
