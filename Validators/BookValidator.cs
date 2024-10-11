using FluentValidation;
using Online_Bookstore.Models;

namespace Online_Bookstore.Validators 
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator() 
        {
            RuleFor(book => book.BookId).NotEqual(0).WithMessage("okkk");
        }
    }
}
