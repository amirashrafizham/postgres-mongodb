using System;
using temp_api.Models;

namespace temp_api.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetSingleBook(string id);
        Book AddBook(Book book);
        Book EditBook(Book book);
        bool DeleteBook(string id);
    }
}
