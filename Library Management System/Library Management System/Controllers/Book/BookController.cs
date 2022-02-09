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
        [HttpPost("Add")]
        public async Task<IActionResult>Add(BookModel bookModel)
        {
            return Ok(new Books().Add(bookModel));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetallBook()
        {
            return Ok(new Books().All());
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult>Update(BookModel bookModel,int Id)
        {
            return Ok(new Books().Update(bookModel, Id));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult>Delete(BookModel bookModel,int Id)
        {
            return Ok(new Books().Delete(bookModel, Id));
        }

        /*[HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateByPatch([FromBody] JsonPatchDocument bookModel, [FromRoute]int Id)
        {
            return Ok(new Books().UpdateBookByPatch(Id,bookModel));
        }*/
        [HttpPost("Issue")]
        public async Task<IActionResult> Issue(BookIssueModel bookIssueModel)
        {
            return Ok(new BookIssues().Issue(bookIssueModel));
        }
        [HttpGet("AllIssue")]
        public async Task<IActionResult> AllIssue()
        {
            return Ok(new BookIssues().AllIssue());
        }

        [HttpPost("Return")]
        public async Task<IActionResult> Return(BookReturnModel bookReturn)
        {
            return Ok(new BookReturns().Return(bookReturn));
        }



    }

    
}
