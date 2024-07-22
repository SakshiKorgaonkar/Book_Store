using Model_Layer;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface IOrderRL
    {
        public Task<List<OrdersEntity>> PlaceOrder(int userId,OrdersML ordersML);
        public Task<List<OrdersEntity>> GetOrder(int userId);
    }
}
