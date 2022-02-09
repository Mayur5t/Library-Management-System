using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Model.Book
{
    public class BookReturnModel
    {
        public DateTime ReturnDate { get; set; }
        public Model.Common.IntegerNullString BookId { get; set; } = new Model.Common.IntegerNullString();
    }
}
