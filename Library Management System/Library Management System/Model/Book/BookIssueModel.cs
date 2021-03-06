using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Model.Book
{
    public class BookIssueModel
    {
        
        [Required(ErrorMessage ="BookId Is Required")]
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "User Is Required")] 
        public Model.Common.IntegerNullString BookId { get; set; } = new Model.Common.IntegerNullString();
    }
}
