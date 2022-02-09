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

        //Insert A Book
        public async Task<string>Add(BookModel value)
        {
            BookDetail books = new BookDetail();
        
            var result=context.BookDetails.FirstOrDefault(X => X.BookName == value.BookName);
            if(result!=null)
            {
                throw new ArgumentException("Book Already Inserted..!");
            }
            else
            {
                books.BookName = value.BookName;
                books.Author = value.Author;
                books.Publisher = value.Publisher;
                books.Price = value.Price;
                books.NumberOfCopies = value.NumberOfCopies;

                context.BookDetails.InsertOnSubmit(books);
                context.SubmitChanges();
                return "Book Inserted..!";

            }
        }

        //Update Book Details
        public async Task<string>Update(BookModel value, int Id)
        {
            
            BookDetail books = context.BookDetails.SingleOrDefault(x => x.BookId == Id);
            if(books !=null)
            {
                books.BookName = value.BookName;
                books.Author = value.Author;
                books.Publisher = value.Publisher;
                books.Price = value.Price;
                books.NumberOfCopies = value.NumberOfCopies;

                context.SubmitChanges();
                return "Book Updated..!";
            }
            return "Book Is Not Available";
        }

        //Update Book By Patch
        /*public async Task<string> UpdateBookByPatch(int Id,JsonPatchDocument b)
        {
            BookDetail books = context.BookDetails.SingleOrDefault(x => x.BookId == Id);
            if(books !=null)
            {
                b.ApplyTo(books);
                context.SubmitChanges();
                return "Book Updated..!";
            }
            return "Invalid Data";
        }*/


        //Delete Book
        public async Task<string> Delete(BookModel value, int Id)
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


        //View All Book
       /* public async Task<IEnumerable>All()
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
        }*/

        public List<Model.Book.BookModel> All()
        {
                var x = (from x1 in context.BookDetails
                         select new Model.Book.BookModel()
                         {
                            // BookId = x1.BookId,
                             BookName = x1.BookName,
                             Author = x1.Author,
                             Publisher = x1.Publisher,
                             Price = (int) x1.Price,
                             NumberOfCopies = (int) x1.NumberOfCopies
                         }).ToList();
                return x;
        }

    }
}
