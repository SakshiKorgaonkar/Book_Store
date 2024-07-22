using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Repository_Layer.Interface
{
    public class CustomerDetailsML
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressType { get; set; }
    }
}