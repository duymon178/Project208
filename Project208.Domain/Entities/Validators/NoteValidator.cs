using FluentValidation;

namespace Project208.Domain.Entities.Validators
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(note => note.NoteId).NotNull();
        }
    }
}
