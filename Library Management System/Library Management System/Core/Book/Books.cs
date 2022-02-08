using Library_Management_System.Model.Book;
using LibraryManagementContext;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Core.Book
{
    public class Books
    {
        LibraryManagementDataContext context = new LibraryManagementDataContext();
        BookDetail books = new BookDetail();
        public async Task<string>AddBook(BookModel b)
        {
            BookDetail books = new BookDetail();
        
            var result=context.BookDetails.FirstOrDefault(X => X.BookName == b.BookName);
            if(result!=null)
            {
                throw new ArgumentException("Book Already Inserted..!");
            }
            else
            {
                books.BookName = b.BookName;
                books.Author = b.Author;
                books.Publisher = b.Publisher;
                books.Price = b.Price;
                books.NumberOfCopies = b.NumberOfCopies;

                context.BookDetails.InsertOnSubmit(books);
                context.SubmitChanges();
                return "Book Inserted..!";

            }
        }

        public async Task<string>Updatebook(BookModel b,int Id)
        {
            
            BookDetail books = context.BookDetails.SingleOrDefault(x => x.BookId == Id);
            if(books !=null)
            {
                books.BookName = b.BookName;
                books.Author = b.Author;
                books.Publisher = b.Publisher;
                books.Price = b.Price;
                books.NumberOfCopies = b.NumberOfCopies;

                context.SubmitChanges();
                return "Book Updated..!";
            }
            return "Book Is Not Available";
        }

        public async Task<string> UpdateBookByPatch(int Id,JsonPatchDocument b)
        {
            BookDetail books = context.BookDetails.SingleOrDefault(x => x.BookId == Id);
            if(books !=null)
            {
                b.ApplyTo(books);
                context.SubmitChanges();
                return "Book Updated..!";
            }
            return "Invalid Data";
        }


        public async Task<string> DeleteBook(BookModel b,int Id)
        {
            BookDetail books = context.BookDetails.SingleOrDefault(X => X.BookId == Id);
            if(books !=null)
            {
                context.BookDetails.DeleteOnSubmit(books);
                context.SubmitChanges();
                return "Book Deleted..!";
            }
            return "Invalid Data";
        }

        public async Task<IEnumerable>GetAllBooks()
        {
            var result = from res in context.BookDetails
                         select res;
            for(int i=0;i< result.Count(); i++)
            {
                var x = (from x1 in context.BookDetails
                         select new
                         {
                             BookId = x1.BookId,
                             BookName = x1.BookName,
                             Author = x1.Author,
                             Publisher = x1.Publisher,
                             Price = x1.Price,
                             NumberOfCopies = x1.NumberOfCopies
                         }).ToList();
                return x;
            }
            return "No Data Found";
        }

    }
}
