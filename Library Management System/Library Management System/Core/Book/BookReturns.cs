using Library_Management_System.Model.Book;
using LibraryManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Core.Book
{
    public class BookReturns
    {
        LibraryManagementDataContext context = new LibraryManagementDataContext();
        public async Task<string>Return(BookReturnModel value)
        {
            BookReturn br = new BookReturn();
            BookDetail bd = new BookDetail();
            var res = context.BookDetails.Single(x => x.BookId == value.BookId.Id);
            br.BookId = res.BookId;
            br.ReturnDate = DateTime.Now;
            bd.NumberOfCopies = bd.NumberOfCopies + 1;

            context.BookReturns.InsertOnSubmit(br);
            context.SubmitChanges();
            return "Book Return Successfully";
        }
    }
}
