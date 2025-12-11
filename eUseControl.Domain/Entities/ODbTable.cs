using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.BaseEntities;   

namespace eUseControl.Domain.Entities
{
     [Table("Orders")]
     public class ODbTable : BaseEntity
    {
        [Required]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Membership name")]
        public string MembershipName { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}


