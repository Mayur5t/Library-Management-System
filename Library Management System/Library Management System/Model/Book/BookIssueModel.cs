using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Model.Book
{
    public class BookIssueModel
    {
        
        [Required]
        public int BookId { get; set; }
        [Required] public DateTime IssueDate { get; set; }
        [Required] public DateTime ReturnDate { get; set; }

        [Required] public Model.Common.IntegerNullString UserId { get; set; } = new Model.Common.IntegerNullString();
    }
}
