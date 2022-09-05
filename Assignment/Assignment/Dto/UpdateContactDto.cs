using FluentValidation;

namespace Assignment.Dto
{
    public class UpdateContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> SecondaryEmails { get; set; }
    }

    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.SecondaryEmails)
                .Must(x => x.Count <= 5)
                .WithMessage("Maximum 5 secondary emails allowed")
                .ForEach(x => x.EmailAddress());
        }
    }
}
