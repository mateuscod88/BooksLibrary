using BooksLibrary.Domain.Enums;
using BooksLibrary.Domain.Policies.Abstractions;

namespace BooksLibrary.Domain.Policies;

public class BookPolicy : IBookPolicy
{
    public bool CanChangeStatus(BookStatus currentStatus, BookStatus newStatus)
    {
        return (newStatus, currentStatus) switch
        {
            (BookStatus.OnTheShelf, BookStatus.Returned) => true,
            (BookStatus.OnTheShelf, BookStatus.Damaged) => true,

            (BookStatus.Borrowed, BookStatus.OnTheShelf) => true,

            (BookStatus.Returned, BookStatus.Borrowed) => true,
            (BookStatus.Returned, BookStatus.Damaged) => true,
            (BookStatus.Damaged,BookStatus.OnTheShelf) => true,
            (BookStatus.Damaged,BookStatus.Returned) => true,
            _ => false 
        };
    }
}