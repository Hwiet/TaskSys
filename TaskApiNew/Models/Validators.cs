using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FluentValidation;

namespace TaskApiNew.Models
{
    public class QuoteValidator : AbstractValidator<Quote>
    {
        private readonly TaskEntities _context;
        public QuoteValidator(TaskEntities context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Id)
                .Length(5)
                .Matches(@"^\d{5}$")
                .WithMessage("{PropertyName} must be 5 digits");

            RuleFor(x => x.Id)
                .Must(id => _context.Quotes.Count(e => e.Id == id) == 0)
                .WithMessage("A quote with the ID {PropertyValue} already exists");

            RuleFor(x => x.QuoteType)
                .NotEmpty()
                .NotEqual(QuoteType.None);

            RuleFor(x => x.TaskType)
                .NotEmpty()
                .NotEqual(TaskType.None);

            RuleFor(x => x.ContactId)
                .Must(contactId => contactId is null || (_context.Personnels.Find(contactId) != null))
                .WithMessage("Specified contact (with contactId {PropertyValue}) does not exist");
        }
    }
}
