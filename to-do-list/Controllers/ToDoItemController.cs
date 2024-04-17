using Microsoft.AspNetCore.Mvc;

namespace to_do_list.Controllers
{
    public class ToDoItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
