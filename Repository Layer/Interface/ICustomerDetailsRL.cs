using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface ICustomerDetailsRL
    {
        public Task<CustomerDetailsEntity> AddCustomerDetails(int userId,CustomerDetailsML customerDetails);
        public Task<CustomerDetailsEntity> UpdateCustomerDetails(int userId,CustomerDetailsML customerDetails);
        public Task<List<CustomerDetailsEntity>> GetCustomerDetails(int userId);
        public Task<CustomerDetailsEntity> DeleteCustomerDetails(int userId,string type);
    }

}
