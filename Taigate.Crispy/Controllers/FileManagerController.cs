using Microsoft.AspNetCore.Mvc;

namespace Taigate.Crispy.Controllers
{
    [Route("CrispyAdmin/filemanager")]
    public class FileManagerController : Controller
    {
        [Route("browse")]
        public IActionResult Browse(string element="")
        {
            ViewBag.Element = element;
            return View();
        }
        
        [Route("tiny-mce")]
        public IActionResult TinyMce()
        {
            return View();
        }
    }
}