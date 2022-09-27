using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TaskApiNew.Models
{
    // Add attributes to generated classes
    // See https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/database-first-development/enhancing-data-validation

    [MetadataType(typeof(QuoteMetadata))]
    public partial class Quote
    {
    }

    public class QuoteMetadata
    {
        [Required]
        public string Id;

        [Required]
        public QuoteType QuoteType;

        [Required]
        public TaskType TaskType;
    }

    [MetadataType(typeof(PersonnelMetadata))]
    public partial class Personnel
    {

    }

    [DataContract]
    public class PersonnelMetadata
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Role;

        // [IgnoreDataMember] doesn't work for some reason
        //public ICollection<Quote> Quotes;
    }
}