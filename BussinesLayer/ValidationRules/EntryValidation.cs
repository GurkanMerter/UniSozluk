using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.ValidationRules
{
    public class EntryValidation : AbstractValidator<Entry>
    {
        public EntryValidation()
        {
            RuleFor(x => x.EntryContent).NotEmpty().WithMessage("Entry İçereğini Boş Geçemezsiniz.");
            RuleFor(x => x.EntryContent).MaximumLength(750).WithMessage("Entry Maksimum Uzunluğu 750 karakterdir.");
            RuleFor(x => x.EntryContent).MinimumLength(10).WithMessage("Entry Minimum Uzunluğu 5 karakterdir.");
        }
    }
}
