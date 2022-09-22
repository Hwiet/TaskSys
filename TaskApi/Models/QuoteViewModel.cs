using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskApi.Models
{
    public class QuoteViewModel
    {
        private readonly TaskContext db = new TaskContext();

        [Required]
        [StringValidator(MinLength = 5, MaxLength = 5)]
        [RegexStringValidator(@"\d{5}")]
        [DisplayName("Quote ID")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Quote Type")]
        public int? QuoteTypeId
        {
            get { return QuoteType?.Id; }
            set { QuoteType = db.QuoteTypes.Find(value); }
        }

        [Required]
        [DisplayName("Task Type")]
        public int? TaskTypeId
        {
            get { return TaskType?.Id; }
            set { TaskType = db.TaskTypes.Find(value); }
        }

        [DisplayName("Description")]
        public string TaskDescription { get; set; }

        public int? ContactId {
            get { return Contact?.Id; }
            set { Contact = db.Personnels.Find(value); }
        }

        [Column(TypeName = "date")]
        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }

        public Personnel Contact { get; set; }
        public QuoteType QuoteType { get; set; }
        public TaskType TaskType { get; set; }
    }
}