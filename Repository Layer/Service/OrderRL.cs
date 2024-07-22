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
    public class OrderRL : IOrderRL
    {
        private readonly ProjectContext projectContext;
        public OrderRL(ProjectContext projectContext)
        {
            this.projectContext = projectContext;
        }
        public async Task<List<OrdersEntity>> GetOrder(int userId)
        {
            return await projectContext.Orders.Where(x=>x.UserId==userId).ToListAsync();
        }

        public async Task<List<OrdersEntity>> PlaceOrder(int userId,OrdersML ordersML)
        {
            List<OrdersEntity> ordersEntities = new List<OrdersEntity>();
            var user = await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            var listOfItem = projectContext.Carts.Where(x => x.UserId == userId).ToList();
            
            if (user == null)
            {
                throw new CustomException("User with given id doesn't exist");
            }
            foreach(var item in listOfItem)
            {
                var result = new OrdersEntity
                {
                    UserId = userId,
                    BookId=item.BookId,
                    BookQuantity=item.BookQuantity,
                    CustomerDetailId = ordersML.CustomerDetailId,
                    TotalPrice = item.TotalPrice,
                };   
                var book=await projectContext.Books.FirstOrDefaultAsync(x => x.BookId == item.BookId);
                book.Quantity -= item.BookQuantity;
                projectContext.Books.Update(book);
                projectContext.SaveChanges();   
                projectContext.Orders.Add(result);
                ordersEntities.Add(result);
                projectContext.Carts.Remove(item);
                
            }
            await projectContext.SaveChangesAsync();
            return ordersEntities;
        }
    }
}
