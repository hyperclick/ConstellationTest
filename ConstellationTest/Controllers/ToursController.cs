using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConstellationTest.Controllers
{
    public class ToursController : Controller
    {
        private ToursRepository repository;

        public ToursController()
        {
            //todo: migrate to DI container
            repository =ToursRepository.Create().Result;
        }
        // GET: Tours
        public ActionResult Index()
        {
            return View(repository.LoadAll());
        }
    }
}