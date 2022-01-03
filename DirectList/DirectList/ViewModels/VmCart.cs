using DirectList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.ViewModels
{
    public class VmCart :VmLayout
    {
        public List<Restaurant> Restaurants { get; set; }
        public Setting Setting { get; set; }
        public List<Social> Socials { get; set; }

    }
}
