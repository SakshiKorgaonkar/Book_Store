using Microsoft.EntityFrameworkCore;
using Model_Layer;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service
{
    public class BookRL : IBookRL
    {
        private readonly ProjectContext projectContext;
        public BookRL(ProjectContext projectContext)
        {
            this.projectContext = projectContext;
        }

        public async Task<BookEntity> AddBook(BookML bookML,int adminId)
        {
            BookEntity bookEntity = new BookEntity();   
            bookEntity.Name = bookML.Name;
            bookEntity.Description = bookML.Description;
            bookEntity.Price = bookML.Price;
            bookEntity.DiscountedPrice = bookML.DiscountedPrice;
            bookEntity.Author = bookML.Author;
            bookEntity.Quantity = bookML.Quantity;
            bookEntity.Image = bookML.Image;
            bookEntity.UserId=adminId;
            projectContext.Books.Add(bookEntity);
            await projectContext.SaveChangesAsync();
            return bookEntity;
        }

        public async Task<BookEntity> GetBookById(int id)
        {
            var book=await projectContext.Books.FirstOrDefaultAsync(x=> x.BookId == id);
            if (book == null) 
            {
                throw new CustomException("Book doesn't exist");
            }
            return book;
        }

        public async Task<List<BookEntity>> GetBooks()
        {
            return await projectContext.Books.ToListAsync();
        }

        public async Task<BookEntity> RemoveBookById(int id)
        {
            var book=await projectContext.Books.FirstOrDefaultAsync(x=>x.BookId == id);
            if(book == null)
            {
                throw new CustomException($"Unable to remove book {id}");
            }
            projectContext.Books.Remove(book);
            await projectContext.SaveChangesAsync();
            return book;
        }

        public async Task<BookEntity> UpdateBookById(int id,BookML bookML,int adminId)
        {
            var book =await projectContext.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (book == null)
            {
                throw new CustomException($"Unable to update book {id}");
            }
            book.Name = bookML.Name;
            book.Description = bookML.Description;
            book.Price = bookML.Price;
            book.DiscountedPrice = bookML.DiscountedPrice;
            book.Author = bookML.Author;
            book.Quantity = bookML.Quantity;
            book.Image = bookML.Image;
            book.UserId= adminId;
            projectContext.Books.Update(book);
            await projectContext.SaveChangesAsync();
            return book;
        }
    }
}
