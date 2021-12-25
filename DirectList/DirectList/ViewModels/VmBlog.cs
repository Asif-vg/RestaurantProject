using DirectList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.ViewModels
{
    public class VmBlog : VmLayout
    {
        public List<Blog> Blogs { get; set; }
    }
}
