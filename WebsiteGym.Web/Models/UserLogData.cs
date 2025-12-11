// using Castle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
// using System.Web; // Not needed in ASP.NET Core
using System.ComponentModel.DataAnnotations;

namespace WebsiteGym.Web.Models
{
     public class UserLogData
     {
          [Required(ErrorMessage ="Username is required")]
          [StringLength(50,MinimumLength = 8, ErrorMessage ="Username not valid")]
          public string UserName { get; set; }
          [Required(ErrorMessage ="Password is required")]
          [StringLength(50, MinimumLength = 5, ErrorMessage ="Password not valid")]
          public string Password { get; set; }
          public DateTime LoginDateTime { get; set; }
     }
}