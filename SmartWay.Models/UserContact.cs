using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace SmartWay.Models
{
    public class UserContact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]

        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }


    }
}
