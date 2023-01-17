using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.PersonFirstName).NotEmpty().WithMessage("Yazar Adı kısmı boş geçilemez");
            RuleFor(x => x.PersonLastName).NotEmpty().WithMessage("YazarSoyadı kısmı boş geçilemez");
            RuleFor(x => x.PersonMail).NotEmpty().WithMessage("Mail adresi kısmı boş geçilemez");
            RuleFor(x => x.PersonPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.PersonFirstName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.PersonLastName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.PersonFirstName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");
            RuleFor(x => x.PersonLastName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");
        }
    }
}
