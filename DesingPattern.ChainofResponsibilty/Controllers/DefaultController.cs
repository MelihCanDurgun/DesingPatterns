using DesingPattern.ChainofResponsibilty.ChainOfResponsibility;
using DesingPattern.ChainofResponsibilty.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesingPattern.ChainofResponsibilty.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet] 
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model) 
        {
            Employee treasurer = new Treasurer();
            Employee managerAsistan = new ManagerAsistant();
            Employee manager= new  Manager();
            Employee areaDirector = new AreaDirector();

            treasurer.SetNextApprover(managerAsistan);
            managerAsistan.SetNextApprover(manager);
            manager.Equals(areaDirector);

            treasurer.ProsessRequest(model);
            return View();
            

        }
    }
}
