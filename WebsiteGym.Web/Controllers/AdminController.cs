using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Discount;
using eUseControl.Domain.Entities.Membership;
using WebsiteGym.Web.Models;


namespace WebsiteGym.Web.Controllers
{
     public class AdminController : BaseController
     {

          private readonly IOrderApi _order;
          private readonly IMembershipApi _membership;
          private readonly IDiscountCode _discount;
          private readonly IUserServices _userServices;
          private readonly IFeedback _feedback;
          private readonly ICoachApi _coach;
          private readonly IEvent _eventApi;
          public AdminController()
          {
               var bl = new BussinesLogic();

               _order = bl.GetOrderApi();
               _membership = bl.GetMembershipApi();
               _discount = bl.GetDiscountApi();
               _userServices = bl.GetUserApi();
               _feedback = bl.GetFeedbackApi();
               _coach = bl.GetCoachApi();
               _eventApi = bl.GetEventApi();
          }

          public ActionResult AdminDash()
          {
               if (Session["UserRole"]?.ToString() == "Admin")
               {
                    ViewBag.UsersNumber = _userServices.GetTotalUsers();
                    ViewBag.ActiveMemberships = _userServices.GetTotalNumberOfActiveMemberships();
                    ViewBag.TotalIncome = _order.GetTotalIncome();
                    ViewBag.TotalFeedbacks = _feedback.GetTotalNumberOfFeedbacks();
                    ViewBag.TotalEvents = _eventApi.GetAllEvents();
                    return View();
               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }

          }

          public ActionResult ListOfUsers()
          {
               if (Session["UserRole"]?.ToString() == "Admin")
               {
                    var users = _userServices.GetAllUsers();
                    ViewBag.Users = users;

                    return View();
               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }

          }

          public ActionResult ListOfActiveMemberships()
        {
            if (Session["UserRole"]?.ToString() == "Admin")
            {
                var memberships = _userServices.GetUsersMemberships();
                ViewBag.UserMemberships = memberships;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

          public ActionResult DeleteUser(int id)
          {
               var user = _userServices.GetUserById(id);
               if (user != null)
               {
                    var success = _userServices.RemoveUserById(id);
                    if (success)
                    {
                         return RedirectToAction("ListOfUsers");
                    }
                    else
                    {
                       
                         TempData["ErrorMessage"] = "Failed to delete user.";
                         return RedirectToAction("ListOfUsers");
                    }
               }
               else
               {
                    TempData["ErrorMessage"] = "User not found.";
                    return RedirectToAction("ListOfUsers");
               }
          }

          public ActionResult ManageDiscountCodes()
          {

               var model = new DiscountViewModel
               {
                    DiscountCodes = _discount.GetAllDiscountCodes()
               };

               return View(model);

          }

          [HttpPost]
          public ActionResult ManageDiscountCodes(DiscountViewModel model)
          {
               if (ModelState.IsValid)
               {
                    var dto = new NewDiscountDto
                    {
                         DiscountCode = model.DiscountCode,
                         DiscountPercentage = (int)model.DiscountPercentage
                    };

                    _discount.CreateDiscountCode(dto);

                    ModelState.Clear();
                    model.DiscountCode = string.Empty;
                    model.DiscountPercentage = null;
               }

               model.DiscountCodes = _discount.GetAllDiscountCodes();

               return View(model);
          }

          [HttpGet]
          public ActionResult EditDiscountCode(int id)
          {
               var discountCode = _discount.GetDiscountCodeById(id);
               if (discountCode == null)
               {
                    return NotFound();
               }

               var model = new DiscountViewModel
               {
                    Id = discountCode.Id,
                    DiscountCode = discountCode.DiscountCode,
                    DiscountPercentage = discountCode.DiscountPercentage,
                    DiscountCodes = _discount.GetAllDiscountCodes()
               };

               return View("ManageDiscountCodes", model);
          }

          [HttpPost]
          public ActionResult EditDiscountCode(DiscountViewModel model)
          {
               if (ModelState.IsValid)
               {
                    _discount.EditDiscountCode(new NewDiscountDto
                    {
                         Id = model.Id,
                         DiscountCode = model.DiscountCode,
                         DiscountPercentage = (int)model.DiscountPercentage,
                    });

                    return RedirectToAction("ManageDiscountCodes");
               }

               model.DiscountCodes = _discount.GetAllDiscountCodes();
               return View("ManageDiscountCodes", model);
          }

          public ActionResult DeleteDiscountCode(int id)
          {
               _discount.RemoveDiscountCode(new NewDiscountDto { Id = id });

               return RedirectToAction("ManageDiscountCodes");
          }

          public ActionResult ManageMemberships()
          {
               if (Session["UserRole"]?.ToString() == "Admin")
               {
                    var model = new MembershipViewModel
                    {
                         Memberships = _membership.GetAllMemberships()
                    };

                    return View(model);
               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }
          }

          [HttpPost]
          public ActionResult ManageMemberships(MembershipViewModel model)
          {
               if (Session["UserRole"]?.ToString() != "Admin")
               {
                    return RedirectToAction("Index", "Home");
               } else { 
               if (!ModelState.IsValid)
               {
                    model.Memberships = _membership.GetAllMemberships();
                    return View(model);
               }

               var dto = new NewMembershipDto
               {
                    membershipName = model.MembershipName,
                    price = (decimal)model.Price,
                    details = model.Details
               };

               _membership.CreateMembership(dto);

               ModelState.Clear();
               model.MembershipName = string.Empty;
               model.Price = null;
               model.Details = string.Empty;

               model.Memberships = _membership.GetAllMemberships();

               return View(model);
               }
          }

          [HttpGet]
          public ActionResult EditMembership(int id)
          {
               var existing = _membership.GetMembershipById(id);

               if (existing == null)
                    return NotFound();

               var model = new MembershipViewModel
               {
                    MembershipId = existing.Id,
                    MembershipName = existing.MembershipName,
                    Price = existing.Price,
                    Details = existing.Details
               };

               return View(model);
          }

          [HttpPost]
          public ActionResult EditMembership(MembershipViewModel membership)
          {
               Debug.WriteLine("=== Received MembershipViewModel ===");
               Debug.WriteLine($"Id: {membership.MembershipId}");
               Debug.WriteLine($"Name: {membership.MembershipName}");
               Debug.WriteLine($"Price: {membership.Price}");
               Debug.WriteLine($"Details: {membership.Details}");

               var dto = new NewMembershipDto
               {
                    membershipId = membership.MembershipId,
                    membershipName = membership.MembershipName,
                    price = membership.Price ?? 0, // Safe fallback
                    details = membership.Details
               };


               var membershipFound = _membership.GetMembershipById(dto.membershipId);
               if (membershipFound == null)
               {
                    ModelState.AddModelError("", "Membership not found.");
                    return RedirectToAction("ManageMemberships");
               }
               else
               {
                    var Edited = _membership.EditMembership(dto);
                    if (Edited)
                    {
                         return RedirectToAction("ManageMemberships");
                    }
                    else
                    {
                         ModelState.AddModelError("", "Failed to edit membership.");
                         return RedirectToAction("ManageMemberships");
                    }
               }

          }

          public ActionResult DeleteMembership(int id)
          {
               _membership.RemoveMembership(new NewMembershipDto { membershipId = id });
               return RedirectToAction("ManageMemberships");
          }

          [HttpGet]
          public ActionResult ManageCoaches()
          {
            if (Session["UserRole"]?.ToString() == "Admin")
            {
                    ViewBag.Coaches = _coach.GetAll();

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          }

        [HttpPost]
        public ActionResult ManageCoaches(CoachViewModel model)
        {

            Debug.WriteLine("=== Received CoachViewModel ===");
            Debug.WriteLine($"Name: {model.Name}");
            Debug.WriteLine($"Surname: {model.Surname}");
            Debug.WriteLine($"Birthdate: {model.Birthdate}");
            Debug.WriteLine($"Speciality: {model.Speciality}");

            if (Session["UserRole"]?.ToString() != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    model.Coaches = _coach.GetAll();
                    return View(model);
                }

                _coach.CreateCoach(model.Name, model.Surname, model.Birthdate, model.Speciality);

                return RedirectToAction("ManageCoaches");

            }
        }

          public ActionResult DeleteCoach(int id)
          {
               _coach.RemoveCoach(id);
               return RedirectToAction("ManageCoaches");
          }

          public ActionResult ListOfFeedbacks()
          {
               if (Session["UserRole"]?.ToString() == "Admin")
               {
                    var feedbacks = _feedback.GetAllFeedbacks();
                    ViewBag.Feedbacks = feedbacks;
                    return View();
               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }
          }

          public ActionResult ListOfOrders()
          {
               if (Session["UserRole"]?.ToString() == "Admin")
               {
                    var orders = _order.GetAllOrders();
                    ViewBag.Orders = orders;
                    return View();
               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }
          }
     }
}