using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities.EventTable;
using Microsoft.AspNetCore.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities;
using WebsiteGym.Web.Models;

namespace WebsiteGym.Web.Controllers
{
     public class FeedbackController : BaseController
     {

          private readonly IFeedback _feedbackApi;
          private readonly IEvent _eventApi;
          public FeedbackController()
          {
               var _bl = new BussinesLogic();
               _feedbackApi = _bl.GetFeedbackApi();
               _eventApi = _bl.GetEventApi();
          }

          public ActionResult Contact()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult CreateFeedback(FeedbackModel model)
          {
               if (ModelState.IsValid) {
                    var feedbackEvent = new EventTable
                    {
                         UserName = model.UserName,
                         Action = "Feedback Submitted",
                         EventTime = DateTime.Now
                    };
                    _eventApi.CreateEvent(feedbackEvent);

                    FeedbackDbTable feedback = new FeedbackDbTable()
                    {
                         UserName = model.UserName,
                         Email = model.Email,
                         FeedbackMessage = model.FeedbackMessage
                    };

                    var created = _feedbackApi.CreateFeedback(feedback);
                    if (created)
                    {
                         return RedirectToAction("ThankYou");
                    }
                    else
                    {
                         ModelState.AddModelError("", "Failed to submit feedback.");
                         return View(model);
                    }

               } else { 

                    ModelState.AddModelError("", "Invalid feedback data.");
               return View(model);
               }
          }
     

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}