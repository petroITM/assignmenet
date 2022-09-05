using FluentValidation;

namespace Assignment.Dto
{
    public class AddContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmail { get; set; }
        public ICollection<string> SecondaryEmails { get; set; }
    }

    public class AddContactDtoValidator : AbstractValidator<AddContactDto>
    {
        public AddContactDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.PrimaryEmail).EmailAddress();
            RuleFor(x => x.SecondaryEmails)
                .Must(x => x.Count <= 5)
                .WithMessage("Maximum 5 secondary emails allowed")
                .ForEach(x => x.EmailAddress());
        }
    }
}
