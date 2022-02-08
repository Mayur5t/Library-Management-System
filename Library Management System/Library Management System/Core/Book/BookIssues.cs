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

        public async Task<string>IssueBook(BookIssueModel bookIssueModel)
        {
            var res = context.BookDetails.Single(x => x.BookId==bookIssueModel.BookId);
            var u = context.SignUps.Single(u => u.UserId == bookIssueModel.UserId.Id);
            bi.BookId = res.BookId;
            bi.UserId = u.UserId;
            bi.IssueDate = DateTime.Now;
            bi.ReturnDate = DateTime.Now.AddDays(10);

            context.BookIssues.InsertOnSubmit(bi);
            context.SubmitChanges();
            return "Book Issue Successfully";
        }

        public async Task<IEnumerable>GetAllIssueBook()
        {
            var result = from res in context.BookIssues
                        select res;
            for (int i = 0; i < result.Count(); i++)
            {
                var x = (from x1 in context.BookIssues
                         select new
                         {
                             IssueId = x1.IssueId,
                             UserId=x1.UserId,
                             BookId = x1.BookId,
                             IssueDate=x1.IssueDate,
                             ReturnDate=x1.ReturnDate
                            
                         }).ToList();
                return x;
            }
            return "No Data Found";
        }
        
      
    }
}
