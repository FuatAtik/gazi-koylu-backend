using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taigate.Crispy.Controllers
{
    [Route("/CrispyAdmin")]
    [CrispyAdminAuth]
    public class CrispyAdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
