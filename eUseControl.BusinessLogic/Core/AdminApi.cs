using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interface;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Discount;
using eUseControl.Domain.Entities.Membership;


namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi : IMembershipApi, IDiscountCode, ICoachApi
    {
        private List<Coach> coachList = new List<Coach>();

        public void CreateMembership(NewMembershipDto membership)
        { 
            if (membership.price < 0)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(membership.membershipName))
            {
                return;
            }

            using (var context = new MembershipContext())
            {
                MDbTable newMembership = new MDbTable()
                {
                    MembershipName = membership.membershipName,
                    Price = membership.price,
                    Details = membership.details
                };

                context.Memberships.Add(newMembership);
                context.SaveChanges(); 
            }
        }

        public void RemoveMembership(NewMembershipDto membership)
        {
            if (membership.membershipId < 0)
            {
                return;
            }

            using (var context = new MembershipContext())
            {
                var membershipToRemove = context.Memberships.FirstOrDefault(m => m.Id == membership.membershipId);

                if (membershipToRemove != null)
                {
                    context.Memberships.Remove(membershipToRemove);
                    context.SaveChanges();
                }
            }
        }

        public bool EditMembership(NewMembershipDto membership)
        {
            if (membership.membershipId < 0)
            {
                return false;
            }

            using (var context = new MembershipContext())
            {
                var membershipToEdit = context.Memberships.FirstOrDefault(m => m.Id == membership.membershipId);

                if (membershipToEdit != null)
                {
                    membershipToEdit.MembershipName = membership.membershipName;
                    membershipToEdit.Price = membership.price;
                    membershipToEdit.Details = membership.details;

                    context.SaveChanges();
                    return true;
                 } else 
                 { 
                         return false; 
                 }
            }
        }

        public MDbTable GetMembershipById(int Id)
        {
            if (Id < 0)
            {
                return null;
            }

            using (var context = new MembershipContext())
            {
                return context.Memberships.FirstOrDefault(m => m.Id == Id);
            }
        }

        public List<MDbTable> GetAllMemberships()
        {
            using (var context = new MembershipContext())
            {
                return context.Memberships.AsEnumerable().OrderBy(m => m.Price).ToList() ;
            }
        }

        public void CreateDiscountCode(NewDiscountDto discount)
        {
            if (discount.DiscountPercentage < 0 || discount.DiscountPercentage > 100)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(discount.DiscountCode))
            {
                return;
            }

            using (var context = new DiscountContext())
            {
                DiscountDbTable newDiscount = new DiscountDbTable()
                {
                    DiscountCode = discount.DiscountCode,
                    DiscountPercentage = discount.DiscountPercentage
                };

                context.DiscountCodes.Add(newDiscount);
                context.SaveChanges();
            }
        }

        public void RemoveDiscountCode(NewDiscountDto discount)
        {
            if (discount.Id < 0)
            {
                return;
            }

            using (var context = new DiscountContext())
            {
                var discountToRemove = context.DiscountCodes.FirstOrDefault(d => d.Id == discount.Id);

                if (discountToRemove != null)
                {
                    context.DiscountCodes.Remove(discountToRemove);
                    context.SaveChanges();
                }
            }
        }

        public void EditDiscountCode(NewDiscountDto discount)
        {
            if (discount.Id < 0)
            {
                return;
            }

            using (var context = new DiscountContext())
            {
                var discountToEdit = context.DiscountCodes.FirstOrDefault(d => d.Id == discount.Id);

                if (discountToEdit != null)
                {
                    discountToEdit.DiscountCode = discount.DiscountCode;
                    discountToEdit.DiscountPercentage = discount.DiscountPercentage;

                    context.SaveChanges();
                }
            }
        }

        public DiscountDbTable GetDiscountCodeById(int Id)
        {
            if (Id < 0)
            {
                return null;
            }

            using (var context = new DiscountContext())
            {
                return context.DiscountCodes.FirstOrDefault(d => d.Id == Id);
            }
        }

        public List<DiscountDbTable> GetAllDiscountCodes()
        {
            using (var context = new DiscountContext())
            {
                return context.DiscountCodes.ToList();
            }
        }

        public void CreateCoach(string name, string surname, DateTime birthdate, string speciality)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                return;
            }

            if (birthdate > DateTime.Now.AddYears(-18))
            {
                return;
            }

            Coach coach = new Coach()
            {
                Name = name,
                Surname = surname,
                Birthdate = birthdate,
                Speciality = speciality
            };

            using (var context = new CoachContext())
            {
                Coach newCoach = new Coach()
                {
                    Name = coach.Name,
                    Surname = coach.Surname,
                    Birthdate = coach.Birthdate,
                    Speciality = coach.Speciality
                };

                context.Coaches.Add(newCoach);
                context.SaveChanges();
            }
        }

        public void RemoveCoach(int coachId)
        {
            if (coachId < 0)
            {
                return;
            }

            foreach (Coach coach in coachList)
            {
                if (coach.Id == coachId)
                {
                    coachList.Remove(coach);
                }
            }
        }

        public Coach GetCoachById(int coachId)
        {
            if (coachId < 0)
            {
                return null;
            }

            foreach (Coach coach in coachList)
            {
                if (coach.Id == coachId)
                {
                    return coach;
                }
            }
            return null;
        }

        public void UpdateCoach(int coachId, string name, string surname, DateTime birthdate)
        {
            if (coachId < 0)
            {
                return;
            }

            foreach (Coach coach in coachList)
            {
                if (coach.Id == coachId)
                {
                    coach.Name = name;
                    coach.Surname = surname;
                    coach.Birthdate = birthdate;

                    return;
                }
            }
        }

        public List<Coach> GetAll()
        {
            using (var context = new CoachContext())
            {
                return context.Coaches.ToList();
            }
        }

          public List<MDbTable> GetTop3Memberships()
          {
               using (var context = new MembershipContext())
               {
                    return context.Memberships.Take(3).ToList();
               }
          }

    }
}