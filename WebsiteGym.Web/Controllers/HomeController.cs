using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using WebsiteGym.Web.Models;
using System.Linq;
using System.Diagnostics;

namespace WebsiteGym.Web.Controllers
{
    public class HomeController : Controller
    {
          private readonly IMembershipApi _membership;
          public HomeController()
          {
               var _bl = new BussinesLogic();
               _membership = _bl.GetMembershipApi() ;
          }

          [HttpGet]
          public ActionResult AuthPage()
          {
               if (Session["UserRole"]?.ToString() == "User")
               {
                    return RedirectToAction("UserDashboard", "Account");
               }
               else if (Session["UserRole"]?.ToString() == "Admin")
               {
                    return RedirectToAction("AdminDash", "Admin");
               }
                   return View();
               }
               
          public ActionResult Index()
        {
            var topMemberships = _membership.GetTop3Memberships();
            return View(topMemberships);
        }

        public ActionResult About()
        {

            return View();
        }

      

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Membership()
        {
               var memberships = _membership.GetAllMemberships();
            return View(memberships);
        }


        public ActionResult ThankYou()
        {
            return View();
        }
    }
}