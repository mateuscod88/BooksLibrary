using System.Text.RegularExpressions;
using FluentValidation;

namespace BooksLibrary.Application.Validation.Books;

public sealed class BookIsbnValidator : AbstractValidator<string>
{
        public BookIsbnValidator()
        {
            RuleFor(isbn => isbn)
                .NotEmpty().WithMessage("ISBN nie może być pusty.")
                .Must(BeValidIsbn).WithMessage("Nieprawidłowy format ISBN.");
        }

        private bool BeValidIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            isbn = isbn.Replace("-", "").Replace(" ", ""); // Usunięcie myślników i spacji

            if (isbn.Length == 10)
                return IsValidIsbn10(isbn);

            if (isbn.Length == 13)
                return IsValidIsbn13(isbn);

            return false;
        }

        private bool IsValidIsbn10(string isbn)
        {
            if (!Regex.IsMatch(isbn, @"^\d{9}[\dX]$"))
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (isbn[i] - '0') * (10 - i);
            }

            char lastChar = isbn[9];
            int lastValue = lastChar == 'X' ? 10 : (lastChar - '0');
            sum += lastValue;

            return sum % 11 == 0;
        }

        private bool IsValidIsbn13(string isbn)
        {
            if (!Regex.IsMatch(isbn, @"^\d{13}$"))
                return false;

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = isbn[i] - '0';
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return checkDigit == (isbn[12] - '0');
        }
}

public static class BookIsbnValidatorExtensions
{
    public static IRuleBuilderOptions<T, string> IsbnValidation<T>(this IRuleBuilder<T, string> ruleBuilder)  => ruleBuilder.SetValidator(new BookIsbnValidator());
}