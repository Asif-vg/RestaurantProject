﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
    public class RestaurantDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
