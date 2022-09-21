namespace TaskApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quote
    {
        [StringLength(5)]
        public string Id { get; set; }

        public int QuoteTypeId { get; set; }

        public int TaskTypeId { get; set; }

        public string TaskDescription { get; set; }

        public int ContactId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public virtual Personnel Personnel { get; set; }

        public virtual QuoteType QuoteType { get; set; }

        public virtual TaskType TaskType { get; set; }
    }
}
