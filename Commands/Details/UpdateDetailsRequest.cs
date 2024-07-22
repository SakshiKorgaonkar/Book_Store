using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class UpdateDetailsRequest : IRequest<CustomerDetailsEntity>
    {
        public string Address {  get; set; }
        public string City {  get; set; }
        public string State {  get; set; }
        public string AddressType {  get; set; }
        public int UserId {  get; set; }

        public UpdateDetailsRequest(string address, string city, string state, string addressType,int id)
        {
            this.Address = address;
            this.City = city;
            this.State = state;
            this.AddressType = addressType;
            this.UserId = id;
        }
    }
}