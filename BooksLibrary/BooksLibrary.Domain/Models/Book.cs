using BooksLibrary.Domain.Enums;

namespace BooksLibrary.Domain.Models;

public class Book
{
    public int Id { get; init; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public BookStatus Status { get; set; } = BookStatus.OnTheShelf;
    public bool IsDeleted { get; set; }
}