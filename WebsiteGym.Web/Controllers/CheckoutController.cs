using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Order;
using eUseControl.Domain.Entities.EventTable;
using eUseControl.Domain.Entities;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebsiteGym.Web.Models;
using Microsoft.AspNetCore.Authentication;

namespace WebsiteGym.Web.Controllers
{
     public class CheckoutController : BaseController
     {
          private readonly IUserServices _userServices;
          private readonly IOrderApi _order;
          private readonly IMembershipApi _membership;
          private readonly IDiscountCode _discountCodeService;
          private readonly IEvent _eventService;
          public CheckoutController()
          {
               var bl = new BussinesLogic();
               _order = bl.GetOrderApi();
               _membership = bl.GetMembershipApi();
               _userServices = bl.GetUserApi();
               _discountCodeService = bl.GetDiscountApi();
               _eventService = bl.GetEventApi();
          }

          // GET: CheckoutMembership
          public ActionResult CheckoutMembership(int membershipId)
          {
               if (Session["UserRole"]?.ToString() == "Admin")
               {
                    return RedirectToAction("AdminDash", "Admin");
               } 
               else if (Session["UserRole"]?.ToString() != "User")
               {
                    return RedirectToAction("AuthPage", "Home");
               }

               var selectedMembership = _membership.GetAllMemberships().FirstOrDefault(m => m.Id == membershipId);

          var model = new OrderViewModel
          {
               AvailableMemberships = _membership.GetAllMemberships(),
               MembershipName = selectedMembership?.MembershipName,
               AvailableDiscountCodes = _discountCodeService.GetAllDiscountCodes(),
          };
     
            return View(model);
           
          }

        [HttpPost]
        public JsonResult CalculatePrice(string membershipName, int membershipDuration)
        {
            var membership = _membership.GetAllMemberships().FirstOrDefault(m => m.MembershipName == membershipName);

            decimal price = (decimal)membership.Price * membershipDuration;

            return Json(new { success = true, subtotal = price, totalPrice = price });
        }

        [HttpPost]
        public JsonResult ApplyDiscount(string membershipName, int membershipDuration, string discountCode)
        {
            var membership = _membership.GetAllMemberships().FirstOrDefault(m => m.MembershipName == membershipName);

            if (membership == null)
            {
                return Json(new { success = false, message = "Invalid membership." });
            }

            var discount = _discountCodeService.GetAllDiscountCodes().FirstOrDefault(d => d.DiscountCode.Equals(discountCode, StringComparison.OrdinalIgnoreCase));

            if (discount == null) 
            {
                return Json(new { success = false, message = "Invalid discount code." });
            }

            decimal price = (decimal)membership.Price * membershipDuration;
            price -= (price * discount.DiscountPercentage / 100m); 

            return Json(new { success = true, subtotal = price, totalPrice = price });
        }


        // POST: CheckoutMembership
        [HttpPost]
        public ActionResult CheckoutMembership(OrderViewModel model)
        {
         var membership = _membership.GetAllMemberships().FirstOrDefault(m => m.MembershipName == model.MembershipName);

               if (membership == null)
               {
                    ModelState.AddModelError("", "Invalid membership.");
                    model.AvailableMemberships = _membership.GetAllMemberships();
                    model.AvailableDiscountCodes = _discountCodeService.GetAllDiscountCodes();
                    return View(model);
               }

               decimal total = ((decimal)membership.Price) * model.MembershipDuration;

               if (!string.IsNullOrEmpty(model.DiscountCode))
               {
                    var discount = _discountCodeService.GetAllDiscountCodes()
                                      .FirstOrDefault(d => d.DiscountCode.Equals(model.DiscountCode, StringComparison.OrdinalIgnoreCase));

                    if (discount != null)
                    {
                         total -= total * discount.DiscountPercentage / 100m;
                    }
                    else
                    {
                         ModelState.AddModelError("", "Invalid discount code.");
                         model.AvailableMemberships = _membership.GetAllMemberships();
                         model.AvailableDiscountCodes = _discountCodeService.GetAllDiscountCodes();
                         return View(model);
                    }
               }

               model.TotalPrice = total;

            if (!ModelState.IsValid)
            {
                    foreach (var entry in ModelState)
                    {
                         foreach (var error in entry.Value.Errors)
                         {
                              System.Diagnostics.Debug.WriteLine($"[Model Error] {entry.Key}: {error.ErrorMessage}");
                         }
                    }

                    model.AvailableMemberships = _membership.GetAllMemberships();
                    model.AvailableDiscountCodes = _discountCodeService.GetAllDiscountCodes();
                    return View(model);
            }
              
               var newOrder = new ODbTable
            {
                UserId = (int)Session["UserId"],
                MembershipName = model.MembershipName,
                UserName = Session["UserName"]?.ToString(),
                OrderDate = DateTime.Now,
                TotalPrice = (decimal)model.TotalPrice
            };


              
            bool created = _order.CreateOrder(newOrder);

            if (!created)
            {
                    ModelState.AddModelError("", "Could not create order.");
                    model.AvailableMemberships = _membership.GetAllMemberships();
                    model.AvailableDiscountCodes = _discountCodeService.GetAllDiscountCodes();
                    return View(model);
             }
               else
             {
                    var purchaseEvent = new EventTable
                    {
                         UserName = (string)Session["UserName"],
                         Action = "User purchased a membership",
                         EventTime = DateTime.Now,
                    };
                    _eventService.CreateEvent(purchaseEvent);

                    int? userId = (int?)Session["UserId"];
                    var newUserMembership = new UserMembership
                    {
                         MembershipType = model.MembershipName,
                         MembershipExperationDate = DateTime.Now.AddMonths(model.MembershipDuration),
                         MembershipPurchaseDate = DateTime.Now,
                    };
                    string qrText = $"User:{userId}|Membership:{model.MembershipName}|Expires:{DateTime.Now.AddMonths(model.MembershipDuration):yyyy-MM-dd}";
                    byte[] qrCode = _userServices.GenerateQrCode(qrText);
                    newUserMembership.QrCodeImage = qrCode;

                    var newMembershipId = _userServices.SaveUserMembership(newUserMembership);

                    if (userId != null && newMembershipId != null)
                    {
                         _userServices.UpdateUserMembership(newMembershipId, userId);
                    }
                    else
                    {
                         ModelState.AddModelError("", "User not found.");
                         model.AvailableMemberships = _membership.GetAllMemberships();
                         model.AvailableMemberships = _membership.GetAllMemberships();
                         return View(model);
                    }

                    return RedirectToAction("OrderSuccess");
             }

                   
        }

        public ActionResult OrderSuccess()
        {
               if (Session["UserRole"]?.ToString() != "User")
               {
                    return RedirectToAction("AuthPage", "Home");
               }
               return View();
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

    }
}
