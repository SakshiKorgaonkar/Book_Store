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
    public class WishlisRL : IWishListRL
    {
        private readonly ProjectContext projectContext;
        public WishlisRL(ProjectContext projectContext)
        {
            this.projectContext = projectContext;
        }
        public async Task<WishlistEntity> AddToWishList(int userd,int bookId)
        {
            var user=await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == userd);
            if (user == null)
            {
                throw new CustomException("User id doesn't exist");
            }
            var item = new WishlistEntity
            {
                UserId = userd,
                BookId = bookId,
            };
            projectContext.Wishlist.Add(item);
            await projectContext.SaveChangesAsync();
            return item;
        }

        public async Task<List<WishlistEntity>> GetWishList(int userId)
        {
            return await projectContext.Wishlist.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<WishlistEntity> RemoveFromWishList(int userId, int bookId)
        {
            var user = await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
            {
                throw new CustomException("User id doesn't exist");
            }
            var wishlistItem=projectContext.Wishlist.FirstOrDefault(x => x.UserId == userId && x.BookId==bookId);
            projectContext.Wishlist.Remove(wishlistItem);
            await projectContext.SaveChangesAsync();
            return wishlistItem;
        }
    }
}
