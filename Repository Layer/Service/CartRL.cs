using Microsoft.EntityFrameworkCore;
using Model_Layer;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service
{
    public class CartRL : ICartRL
    {
        private readonly ProjectContext projectContext;
        public CartRL(ProjectContext projectContext)
        {
            this.projectContext = projectContext;
        }
        public async Task<CartEntity> AddToCart(CartML cartML, int userId)
        {
            var book = await projectContext.Books.FirstOrDefaultAsync(x => x.BookId == cartML.BookId);
            var user = await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            var cartItem = await projectContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId && c.BookId == cartML.BookId);
            if(projectContext.Carts.Contains(cartItem))
            {
                throw new CustomException("Book already exists in cart !! Try to update cart instead");
            }
            if (book == null)
            {
                throw new CustomException("Book with given id doesn't exist");
            }
            if (user == null)
            {
                throw new CustomException("User with given id doesn't exist");
            }
            if (cartML.Quantity > book.Quantity)
            {
                throw new CustomException($"Book quantity exceeded the stock available by {cartML.Quantity - book.Quantity}");
            }
            var cartEntity = new CartEntity
            {
                BookId = cartML.BookId,
                BookQuantity = cartML.Quantity,
                UserId = userId,
                TotalPrice=cartML.Quantity*book.DiscountedPrice
            };
            projectContext.Carts.Add(cartEntity);
            await projectContext.SaveChangesAsync();
            return cartEntity;
        }

        public async Task<CartEntity> DeleteFromCart(int userId, int bookId)
        {
            var cartItem = await projectContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId && c.BookId == bookId);
            if (cartItem == null)
            {
                throw new CustomException("Book doesn't exist in the cart");
            }
            projectContext.Carts.Remove(cartItem);
            await projectContext.SaveChangesAsync();
            return cartItem;
        }

        public async Task<List<CartEntity>> GetCart(int userId)
        {
            var cartItems = await projectContext.Carts.Where(x => x.UserId == userId).Include(c=>c.Book).ThenInclude(c=>c.User).Include(c=>c.User).ToListAsync();
            return cartItems;
        }

        public async Task<CartEntity> UpdateCart(int userId, CartML cartML)
        {
            var book=await projectContext.Books.FirstOrDefaultAsync(x=>x.BookId == cartML.BookId);
            var user=await projectContext.Users.FirstOrDefaultAsync(x=>x.UserId == userId);
            var cartItem = await projectContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId && c.BookId == cartML.BookId);
            if (book == null)
            {
                throw new CustomException("Book with given id doesn't exist");
            }
            if (user == null)
            {
                throw new CustomException("User with given id doesn't exist");
            }
            if (cartItem == null)
            {
                throw new CustomException("Cart item with given book id doesn't exist");
            }
            if (cartML.Quantity > book.Quantity)
            {
                throw new CustomException($"Book quantity exceeded than stock available by {cartML.Quantity - book.Quantity}");
            }
            cartItem.BookQuantity = cartML.Quantity;
            cartItem.BookId = cartML.BookId;
            cartItem.TotalPrice = cartML.Quantity * book.DiscountedPrice;
            projectContext.Carts.Update(cartItem);
            await projectContext.SaveChangesAsync();
            return cartItem;
        }
    }
}
