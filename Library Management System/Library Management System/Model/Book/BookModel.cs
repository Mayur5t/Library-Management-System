using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Model.Book
{
    public class BookModel
    {
        [Required(ErrorMessage = "Book Name Is Required")] public string BookName { get; set; }
        [Required(ErrorMessage = "Author Name Is Required")] public string Author { get; set; }
        [Required(ErrorMessage = "Publisher Name Is Required")] public string Publisher { get; set; }
        [Required(ErrorMessage = "Price Is Required")] public int Price { get; set; }
        [Required] public int NumberOfCopies { get; set; }
    }
}
