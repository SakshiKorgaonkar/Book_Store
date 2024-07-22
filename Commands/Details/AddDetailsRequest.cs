using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Controllers
{
    public class AddDetailsRequest : IRequest<CustomerDetailsEntity>
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressType { get; set; }
        public int UserId { get; set; }

        public AddDetailsRequest(string address,string city,string state,string type,int id)
        {
            this.Address = address;
            this.City = city;
            this.State = state;
            this.AddressType= type;
            this.UserId = id;
        }
    }
}