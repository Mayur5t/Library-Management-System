using Library_Management_System.Core.Book;
using Library_Management_System.Model.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Controllers.Book
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookIssueController : ControllerBase
    {
        [HttpPost("BookIssue")]
        public async Task<IActionResult> IssueBook(BookIssueModel bookIssueModel)
        {
            return Ok(new BookIssues().IssueBook(bookIssueModel));
        }
        [HttpGet("GetAllIssueBook")]
        public async Task<IActionResult> GetAllIssueBook()
        {
            return Ok(new BookIssues().GetAllIssueBook());
        }
    }

    
   
}
