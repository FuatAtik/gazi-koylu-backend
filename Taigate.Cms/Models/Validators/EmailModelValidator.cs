using System.Text.RegularExpressions;
using FluentValidation;

namespace Taigate.Cms.Models.Validators
{
    public class EmailModelValidator : AbstractValidator<EmailModel> {
        public EmailModelValidator() {
            RuleFor(x => x.Name).Length(5, 20);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).Custom((x, _) =>
            {
                IsPhoneNumber(x);
            });
            RuleFor(x => x.Subject).Length(2, 20);
            RuleFor(x => x.Message).Length(5, 200);
        }
        
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

    }

}