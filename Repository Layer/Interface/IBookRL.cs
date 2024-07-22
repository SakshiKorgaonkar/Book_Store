using Model_Layer;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface IBookRL
    {
        public Task<BookEntity> AddBook(BookML bookML,int adminId);
        public Task<BookEntity> RemoveBookById(int id);
        public Task<BookEntity> GetBookById(int id);
        public Task<BookEntity> UpdateBookById(int id,BookML bookML,int adminId);
        public Task<List<BookEntity>> GetBooks();
    }
}
