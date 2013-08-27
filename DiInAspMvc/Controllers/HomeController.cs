using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DiInAspMvc.Models;

namespace DiInAspMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExpensiveCarsRepository expensiveCarsRepository;

        public HomeController(IExpensiveCarsRepository expensiveCarsRepository)
        {
            this.expensiveCarsRepository = expensiveCarsRepository;
        }

        public ActionResult Index()
        {
            IEnumerable<Car> expensiveCars = expensiveCarsRepository.GetExpensive();
            return View(expensiveCars);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}
