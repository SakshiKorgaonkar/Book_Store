using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class CustomerDetailsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerDetailId { get; set; }
        [Required]
        public string Address {  get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string AddressType { get; set; }
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public UserEntity? User {  get; set; }
        [JsonIgnore]
        public ICollection<OrdersEntity> Orders { get; set;}
    }
}
