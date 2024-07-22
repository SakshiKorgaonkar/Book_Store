using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
    public class CustomerDetailsRL : ICustomerDetailsRL
    {
        private readonly ProjectContext projectContext;
        public CustomerDetailsRL(ProjectContext projectContext)
        {
            this.projectContext = projectContext;
        }
        public async Task<CustomerDetailsEntity> AddCustomerDetails(int userId, CustomerDetailsML customerDetails)
        {
            var user=await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user==null)
            {
                throw new CustomException("User id doesn't exist");
            }
            var detailItem = await projectContext.CustomerDetails.FirstOrDefaultAsync(c => c.UserId == userId && c.AddressType == customerDetails.AddressType);
            if (projectContext.CustomerDetails.Contains(detailItem))
            {
                throw new CustomException("Book already exists in cart !! Try to update cart instead");
            }
            var details = new CustomerDetailsEntity
            {
                Address = customerDetails.Address,
                City = customerDetails.City,
                State = customerDetails.State,
                AddressType = customerDetails.AddressType,
                UserId = userId
               
            };
            projectContext.CustomerDetails.Add(details);
            await projectContext.SaveChangesAsync();
            return details;
        }

        public async Task<CustomerDetailsEntity> DeleteCustomerDetails(int userId, string type)
        {
            var user = await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
            {
                throw new CustomException("User id doesn't exist");
            }
            var details = await projectContext.CustomerDetails.FirstOrDefaultAsync(x => x.UserId == userId && x.AddressType == type);
            projectContext.CustomerDetails.Remove(details);
            await projectContext.SaveChangesAsync();
            return details;
        }

        public async Task<List<CustomerDetailsEntity>> GetCustomerDetails(int userId)
        {

            return await projectContext.CustomerDetails.Where(x=>x.UserId==userId).Include(c=>c.User).ToListAsync();
        }

        public async Task<CustomerDetailsEntity> UpdateCustomerDetails(int userId, CustomerDetailsML customerDetails)
        {
            var user = await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
            {
                throw new CustomException("User id doesn't exist");
            }
            var details = await projectContext.CustomerDetails.FirstOrDefaultAsync(x => x.UserId == userId);
            if (details == null)
            {
                throw new CustomException("Details for given user id don't exits, try adding details first");
            }
            details.State = customerDetails.State;
            details.Address=customerDetails.Address;
            details.City=customerDetails.City;
            details.AddressType=customerDetails.AddressType;
            projectContext.CustomerDetails.Update(details);
            await projectContext.SaveChangesAsync();
            return details;
        }
    }
}
