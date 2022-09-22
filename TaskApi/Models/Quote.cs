namespace TaskApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;

    public partial class Quote
    {
        [Display(Name = "Quote ID")]
        [Required(ErrorMessage = "ID is required")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter a 5-digit numeric ID")]
        [Remote("IdExists", "Quotes", ErrorMessage = "A quote with this ID already exists")]
        public string Id { get; set; }

        [Display(Name = "Quote Type")]
        [Required(ErrorMessage = "Select the quote type")]
        public int QuoteTypeId { get; set; }

        [Display(Description = "Task Category")]
        [Required(ErrorMessage = "Select a category for this task")]
        public int TaskTypeId { get; set; }

        [Display(Name = "Description of Task")]
        public string TaskDescription { get; set; }

        [Display(Name = "Point of Contact")]
        public int? ContactId { get; set; }

        [Display(Name = "Due Date")]
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Point of Contact")]
        public virtual Personnel Contact { get; set; }

        [Display(Name = "Quote Type")]
        public virtual QuoteType QuoteType { get; set; }

        [Display(Name = "Task Category")]
        public virtual TaskType TaskType { get; set; }
    }
}
