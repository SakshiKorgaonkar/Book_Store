using Model_Layer;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface ICartRL
    {
        public Task<CartEntity> AddToCart(CartML cartML,int userId);
        public Task<CartEntity> UpdateCart(int userId,CartML cartML);
        public Task<CartEntity> DeleteFromCart(int userId,int bookId);
        public Task<List<CartEntity>> GetCart(int userId);
    }
}
