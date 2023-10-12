using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace SmartWay.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Project Name")]
        public string Name { get; set; } = "New Project";
        public string? Description { get; set; } = "New Project Description";

        [ValidateNever]
        [Display(Name = "Project Image")]
        public byte[] ProjectImage { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        //[ForeignKey("CategoryId")]

        [ValidateNever]
        public Category? Category { get; set; } //navigation property for the Category model
    }
}
