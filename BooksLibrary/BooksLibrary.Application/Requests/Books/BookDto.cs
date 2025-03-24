using BooksLibrary.Domain.Enums;

namespace BooksLibrary.Application.Requests.Books;

public record BookDto(int Id, string Title, string Author, string Isbn, BookStatus Status);