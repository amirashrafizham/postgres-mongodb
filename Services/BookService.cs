using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using temp_api.Data;
using temp_api.Interfaces;
using temp_api.Models;

namespace temp_api.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public BookService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDataBase = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);
            _booksCollection = mongoDataBase.GetCollection<Book>(bookStoreDatabaseSettings.Value.BooksCollectionName);
        }
        List<Book> books = new List<Book>()
        {
            new Book(){Name = "Lord of the Rings", Price = 12},
            new Book(){Name = "Harry Potter", Price = 20},
        };
        public List<Book> GetBooks()
        {
            var query = _booksCollection.Find(x => true).ToList();
            return query;
        }

        public Book GetSingleBook(string id)
        {
            var query = _booksCollection.Find(x => x.Id == id).FirstOrDefault();
            return query;
        }

        public Book AddBook(Book book)
        {
            _booksCollection.InsertOne(book);
            return book;
        }

        public bool DeleteBook(string id)
        {
            var query = _booksCollection.DeleteOne(x => x.Id == id);
            if (query.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public Book EditBook(Book book)
        {
            _booksCollection.ReplaceOne(x => x.Id == book.Id, book);
            return book;
        }
    }
}
