using BooksLibrary.Application.Shared.Abstractions;
using BooksLibrary.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BooksLibrary.Infrastructure.Persistance.Seeds;

public static class DbSeeder
{
    public static void SeedData(IAppDbContext context)
    {
        if (!context.Books.Any()) 
        {
            context.Books.AddRange(new List<Book>
            {
                new Book { Id = 1, Title = "Lalka", Author = "Bolesław Prus", Isbn = "978-8377992012" },
                new Book { Id = 2, Title = "Potop", Author = "Henryk Sienkiewicz", Isbn = "978-8379420629" },
                new Book { Id = 3, Title = "Krzyżacy", Author = "Henryk Sienkiewicz", Isbn = "978-8379670000" },
                new Book { Id = 4, Title = "Ziemia obiecana", Author = "Władysław Reymont", Isbn = "978-8377999452" },
                new Book { Id = 5, Title = "Chłopi", Author = "Władysław Reymont", Isbn = "978-8377999469" },
                new Book { Id = 6, Title = "Quo Vadis", Author = "Henryk Sienkiewicz", Isbn = "978-8379670017" },
                new Book { Id = 7, Title = "Pan Tadeusz", Author = "Adam Mickiewicz", Isbn = "978-8379980001" },
                new Book { Id = 8, Title = "Ferdydurke", Author = "Witold Gombrowicz", Isbn = "978-8307030954" },
                new Book { Id = 9, Title = "Solaris", Author = "Stanisław Lem", Isbn = "978-8378931171" },
                new Book { Id = 10, Title = "Bajki robotów", Author = "Stanisław Lem", Isbn = "978-8378931188" },
                new Book { Id = 11, Title = "Dzienniki gwiazdowe", Author = "Stanisław Lem", Isbn = "978-8378931195" },
                new Book
                {
                    Id = 12, Title = "Szpital Przemienienia", Author = "Stanisław Lem", Isbn = "978-8378931201"
                },
                new Book { Id = 13, Title = "Cień wiatru", Author = "Carlos Ruiz Zafón", Isbn = "978-8377475958" },
                new Book { Id = 14, Title = "Przedwiośnie", Author = "Stefan Żeromski", Isbn = "978-8379060213" },
                new Book { Id = 15, Title = "Syzyfowe prace", Author = "Stefan Żeromski", Isbn = "978-8377992001" },
                new Book { Id = 16, Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski", Isbn = "978-8379980017" },
                new Book { Id = 17, Title = "Idiota", Author = "Fiodor Dostojewski", Isbn = "978-8379980024" },
                new Book { Id = 18, Title = "Gra o Tron", Author = "George R.R. Martin", Isbn = "978-8375060881" },
                new Book
                {
                    Id = 19, Title = "Wiedźmin: Ostatnie Życzenie", Author = "Andrzej Sapkowski",
                    Isbn = "978-8375780642"
                },
                new Book
                {
                    Id = 20, Title = "Wiedźmin: Miecz Przeznaczenia", Author = "Andrzej Sapkowski",
                    Isbn = "978-8375780659"
                },
                new Book
                {
                    Id = 21, Title = "Wiedźmin: Krew Elfów", Author = "Andrzej Sapkowski", Isbn = "978-8375780666"
                },
                new Book
                {
                    Id = 22, Title = "Wiedźmin: Czas Pogardy", Author = "Andrzej Sapkowski", Isbn = "978-8375780673"
                },
                new Book
                {
                    Id = 23, Title = "Wiedźmin: Chrzest Ognia", Author = "Andrzej Sapkowski", Isbn = "978-8375780680"
                },
                new Book
                {
                    Id = 24, Title = "Wiedźmin: Wieża Jaskółki", Author = "Andrzej Sapkowski", Isbn = "978-8375780697"
                },
                new Book
                {
                    Id = 25, Title = "Wiedźmin: Pani Jeziora", Author = "Andrzej Sapkowski", Isbn = "978-8375780703"
                },
                new Book { Id = 26, Title = "Opowieści z Narnii", Author = "C.S. Lewis", Isbn = "978-8372783302" },
                new Book { Id = 27, Title = "Duma i uprzedzenie", Author = "Jane Austen", Isbn = "978-8375060028" },
                new Book
                {
                    Id = 28, Title = "Władca Pierścieni: Drużyna Pierścienia", Author = "J.R.R. Tolkien",
                    Isbn = "978-8375068253"
                },
                new Book
                {
                    Id = 29, Title = "Władca Pierścieni: Dwie Wieże", Author = "J.R.R. Tolkien", Isbn = "978-8375068260"
                },
                new Book
                {
                    Id = 30, Title = "Władca Pierścieni: Powrót Króla", Author = "J.R.R. Tolkien",
                    Isbn = "978-8375068277"
                },
                new Book { Id = 31, Title = "Opowieść wigilijna", Author = "Charles Dickens", Isbn = "978-8375068284" },
                new Book
                {
                    Id = 32, Title = "Mały Książę", Author = "Antoine de Saint-Exupéry", Isbn = "978-8375068291"
                },
                new Book { Id = 33, Title = "Metro 2033", Author = "Dmitrij Głuchowski", Isbn = "978-8375068307" },
                new Book { Id = 34, Title = "Metro 2034", Author = "Dmitrij Głuchowski", Isbn = "978-8375068314" },
                new Book { Id = 35, Title = "Metro 2035", Author = "Dmitrij Głuchowski", Isbn = "978-8375068321" },
                new Book { Id = 36, Title = "Ludzie bezdomni", Author = "Stefan Żeromski", Isbn = "978-8375068338" },
                new Book { Id = 37, Title = "Zamek", Author = "Franz Kafka", Isbn = "978-8375068345" },
                new Book
                {
                    Id = 38, Title = "Mistrz i Małgorzata", Author = "Michaił Bułhakow", Isbn = "978-8375068352"
                },
                new Book { Id = 39, Title = "Pachnidło", Author = "Patrick Süskind", Isbn = "978-8375068369" },
                new Book { Id = 40, Title = "Kod Leonarda da Vinci", Author = "Dan Brown", Isbn = "978-8375068376" }
            });

            context.SaveChanges();
        }
    }
}