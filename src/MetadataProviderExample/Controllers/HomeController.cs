using Microsoft.AspNet.Mvc;

namespace MetadataProviderExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View(new Model());
        }
    }
}
