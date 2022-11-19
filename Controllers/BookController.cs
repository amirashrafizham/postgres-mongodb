using System;
using Microsoft.AspNetCore.Mvc;
using temp_api.DTOs;
using temp_api.Interfaces;
using temp_api.Models;

namespace temp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("books")]
        public ActionResult GetBooks()
        {
            var query = bookService.GetBooks();
            return Ok(query);
        }

        [HttpGet]
        [Route("book/{id}")]
        public ActionResult GetSingleBook(string id)
        {
            var query = bookService.GetSingleBook(id);
            if (query is null)
            {
                return NotFound("not found");
            }
            return Ok(query);
        }

        [HttpPost]
        [Route("addbook")]
        public ActionResult AddBook(Book book)
        {
            var query = bookService.AddBook(book);
            return CreatedAtAction("GetSingleBook", new { Id = query.Id }, query);
        }

        [HttpPut]
        [Route("editbook")]
        public ActionResult EditBook(Book book)
        {
            var query = bookService.EditBook(book);
            return Ok(query);
        }

        [HttpDelete]
        [Route("deletebook/{id}")]
        public ActionResult DeleteBook(string id)
        {
            var query = bookService.DeleteBook(id);
            if (query is false)
            {
                return NotFound("not found");
            }
            return Ok("book deleted");
        }


    }
}
