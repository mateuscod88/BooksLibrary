using AutoMapper;
using BooksLibrary.Application.Requests.Books.Commands.CreateBook;
using BooksLibrary.Domain.Models;

namespace BooksLibrary.Application.Requests.Books;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateBookCommand, Book>();
    }
}