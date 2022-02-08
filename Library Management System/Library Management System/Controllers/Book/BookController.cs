using Library_Management_System.Core.Book;
using Library_Management_System.Model.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Controllers.Book
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class BookController : ControllerBase
    {
        [HttpPost("AddBook")]
        public async Task<IActionResult>InsertBook(BookModel bookModel)
        {
            return Ok(new Books().AddBook(bookModel));
        }

        [HttpGet("GetAllBook")]
        public async Task<IActionResult> GetallBook()
        {
            return Ok(new Books().GetAllBooks());
        }

        [HttpPut("{Book_Id}")]
        public async Task<IActionResult>UpdateBook(BookModel bookModel,int Book_Id)
        {
            return Ok(new Books().Updatebook(bookModel, Book_Id));
        }

        [HttpDelete("{Book_Id}")]
        public async Task<IActionResult>DeleteBook(BookModel bookModel,int Book_Id)
        {
            return Ok(new Books().DeleteBook(bookModel, Book_Id));
        }

        [HttpPatch("{Book_Id}")]
        public async Task<IActionResult> UpdateByPatch([FromBody] JsonPatchDocument bookModel, [FromRoute]int Book_Id)
        {
            return Ok(new Books().UpdateBookByPatch(Book_Id,bookModel));
        }

        

        


    }

    
}
