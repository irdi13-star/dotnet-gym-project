using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebsiteGym.Web.Models
{
     public class EditUserProfileDTO
     {
          public int Id { get; set; }
          public string UserName { get; set; }
          public string FullName { get; set; }
          public string Email { get; set; }
          public string PhoneNumber { get; set; }
     }
}