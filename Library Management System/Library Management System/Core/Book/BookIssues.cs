using Library_Management_System.Model.Book;
using LibraryManagementContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Core.Book
{
    public class BookIssues
    {
        LibraryManagementDataContext context = new LibraryManagementDataContext();
        BookIssue bi = new BookIssue();
        BookDetail bd = new BookDetail();

        public async Task<string>Issue(BookIssueModel value)
        {
            var res = context.BookDetails.Single(x => x.BookId== value.BookId.Id);
            bi.BookId = res.BookId;
            bi.IssueDate = DateTime.Now;
            bi.ReturnDate = DateTime.Now.AddDays(10);
            bd.NumberOfCopies = bd.NumberOfCopies - 1;
            context.BookIssues.InsertOnSubmit(bi);
            context.SubmitChanges();
            return "Book Issue Successfully";
        }

        public List<Model.Book.BookIssueModel>AllIssue()
        {
                var x = (from x1 in context.BookIssues
                         select new Model.Book.BookIssueModel
                         {
                            // IssueId = x1.IssueId,
                            // BookId= (int)x1.BookId.id,
                             IssueDate= (DateTime)x1.IssueDate,
                             ReturnDate=(DateTime)x1.ReturnDate
                            
                         }).ToList();
                return x;
  
        }

        /*public List<Model.Book.BookModel> All()
        {
            var x = (from x1 in context.BookDetails
                     select new Model.Book.BookModel()
                     {
                         // BookId = x1.BookId,
                         BookName = x1.BookName,
                         Author = x1.Author,
                         Publisher = x1.Publisher,
                         Price = (int)x1.Price,
                         NumberOfCopies = (int)x1.NumberOfCopies
                     }).ToList();
            return x;
        }*/
    }
}
