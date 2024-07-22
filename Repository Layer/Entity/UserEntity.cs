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
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public string Role { get; set; }
        [JsonIgnore]
        public ICollection<BookEntity> Books { get; set; }
        [JsonIgnore]
        public ICollection<CartEntity> Carts { get; set; } 
        [JsonIgnore]
        public ICollection<CustomerDetailsEntity> CustomerDetails { get; set; }
        [JsonIgnore]
        public ICollection<OrdersEntity> Orders { get; set; }
        [JsonIgnore]
        public ICollection<WishlistEntity> Wishlist { get; set; }
    }
}
