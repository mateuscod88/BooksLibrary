using BooksLibrary.Domain.Enums;
using BooksLibrary.Domain.Models;

namespace BooksLibrary.Domain.Policies.Abstractions;

public interface IBookPolicy
{
    bool CanChangeStatus(BookStatus currentStatus, BookStatus newStatus);
}