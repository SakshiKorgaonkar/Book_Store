using Model_Layer;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface IWishListRL
    {
        public Task<List<WishlistEntity>> GetWishList(int userId);
        public Task<WishlistEntity> AddToWishList(int userId,int bookId);
        public Task<WishlistEntity> RemoveFromWishList(int userId,int bookId);
    }
}
