using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TaskApi.Models
{
    public class QuoteViewModel
    {
        private readonly TaskContext db = new TaskContext();

        [Required]
        [StringValidator(MinLength = 5, MaxLength = 5)]
        [RegexStringValidator(@"\d{5}")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Quote Type")]
        public string QuoteType { get; set; }

        [Required]
        [DisplayName("Task Type")]
        public string TaskType { get; set; }

        [DisplayName("Description")]
        public string TaskDescription { get; set; }

        public string Contact { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }

        public QuoteViewModel(Quote quote)
        {
            Id = quote.Id;
            QuoteType = quote.QuoteType.Name;
            TaskType = quote.TaskType.Name;
            TaskDescription = quote.TaskDescription;
            Contact = quote.Personnel.Role;
            DueDate = quote.DueDate;
        }
    }
}