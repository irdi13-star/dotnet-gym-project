using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Helper.AssistingLogic;
using Microsoft.Win32;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Order;

namespace eUseControl.BusinessLogic.Core
{
     public class UserServices : IUserServices
     {
          public UserMembership GetUserMembershipById(int id)
          {
               using (var context = new UserContext())
               {
                    return context.UserMemberships.FirstOrDefault(u => u.Id == id);
               }
          }

          public User GetUserById(int id)
          {
               using (var context = new UserContext())
               {
                    return context.Users.FirstOrDefault(u => u.Id == id);
               }
          }

          public User GetUserByEmail(string email)
          {
               using (var context = new UserContext())
               {
                    return context.Users.FirstOrDefault(u => u.Email == email);
               }

          }

          public bool RegisterUser(User user)
          {
               var helper = new UserHelper();
               using (var context = new UserContext())
               {
                    if ((context.Users.Any(u => u.Email == user.Email) || (context.Users.Any(u => u.Name == user.Name))))
                    {
                         return false;
                    }

                    user.Password = helper.PasswordHash(user.Password);
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
               }

          }

          public User LoginUser(User user)
          {
               var helper = new UserHelper();
               var hashedPassword = helper.PasswordHash(user.Password);
               using (var context = new UserContext())
               {
                    var UserExists = context.Users.FirstOrDefault(u => u.Name == user.Name && u.Password == hashedPassword);
                    if (UserExists != null)
                    {
                         return UserExists;
                    }
                    else
                    {
                         return null;
                    }
               }
          }

          public bool RemoveUser(string name, string email)
          {
               return true;
          }

          public bool CreateNewOrderAction(ODbTable order)
          {
               if (order.TotalPrice < 0)
               {
                    return false;
               }

               using (var context = new OrderContext())
               {
                    context.Orders.Add(order);
                    context.SaveChanges();
               }
               return true;
          }

          public int? SaveUserMembership(UserMembership userMembership)
          {
               if (userMembership == null)
               {
                    return null;
               }
               using (var context = new UserContext())
               {
                    context.UserMemberships.Add(userMembership);
                    context.SaveChanges();
                    return userMembership.Id;
               }
          }

          public bool UpdateUserMembership(int? userMembershipId, int? userId)
          {
               using (var context = new UserContext())
               {
                    var user = context.Users.FirstOrDefault(u => u.Id == userId);
                    if (user == null)
                         return false;

                    if (user.UserMembershipID != null)
                    {
                         var userMembership = context.UserMemberships.FirstOrDefault(u => u.Id == user.UserMembershipID);
                         if (userMembership != null)
                         {
                              context.UserMemberships.Remove(userMembership);
                              context.SaveChanges();
                         }
                    }
                    user.UserMembershipID = userMembershipId;
                    user.MembershipStatus = true;

                    context.SaveChanges();
                    return true;

               }
          }

          public bool UpdateUserPassword(User user, string newPassword)
          {
               var helper = new UserHelper();
               using (var context = new UserContext())
               {
                    var hashedPassword = helper.PasswordHash(newPassword);
                    var userToUpdate = context.Users.FirstOrDefault(u => u.Id == user.Id);
                    if (userToUpdate != null)
                    {
                         userToUpdate.Password = hashedPassword;
                         context.SaveChanges();
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }

          public byte[] GenerateQrCode(string qrText)
          {
               var helper = new CheckoutHelper();
               return helper.GenerateQrCode(qrText);
          }

          public bool RemoveUserMembership(int id)
          {
               using (var context = new UserContext())
               {
                    var userMembership = context.UserMemberships.FirstOrDefault(u => u.Id == id);
                    if (userMembership != null)
                    {
                         context.UserMemberships.Remove(userMembership);
                         context.SaveChanges();
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }

          public int GetTotalUsers()
          {
               using (var context = new UserContext())
               {
                    return context.Users.Count();
               }
          }

          public int GetTotalNumberOfActiveMemberships()
          {
               using (var context = new UserContext())
               {
                    return context.Users.Count(u => u.MembershipStatus == true);
               }
          }

          public List<User> GetAllUsers()
          {
               using (var context = new UserContext())
               {
                    return context.Users.ToList();
               }
          }

          public bool RemoveUserById(int id)
          {
               using (var context = new UserContext())
               {
                    var user = context.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                         context.Users.Remove(user);
                         context.SaveChanges();
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }

          public bool UpdateUser(User user)
          {
               using (var context = new UserContext())
               {
                    var userToUpdate = context.Users.FirstOrDefault(u => u.Id == user.Id);
                    if (userToUpdate != null)
                    {
                         userToUpdate.Name = user.Name;
                         userToUpdate.Email = user.Email;
                         userToUpdate.FullName = user.FullName;
                         userToUpdate.PhoneNumber = user.PhoneNumber;
                         userToUpdate.ProfilePicture = user.ProfilePicture;
                         context.SaveChanges();
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }

          public List<UserMembership> GetUsersMemberships()
          {
               using (var context = new UserContext())
               {
                    return context.UserMemberships.ToList();
               }

          }

          public List<ODbTable> GetUserPaymentHistory(int id)
          {
               var userFound = GetUserById(id);
               if (userFound != null)
               {
                    using (var context = new OrderContext())
                    {
                         return context.Orders
                                .Where(o => o.UserId == id)
                                .OrderByDescending(o => o.OrderDate) 
                                .ToList();  
                         
                         
                    }
                  
               }  

               return null;
             
          }
     }
}
