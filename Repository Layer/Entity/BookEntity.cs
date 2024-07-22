using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int DiscountedPrice {  get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Image {  get; set; }
        [ForeignKey("UserEntity")]
        public int UserId {  get; set; }
        public UserEntity User { get; set; }
        [JsonIgnore]
        public ICollection<CartEntity> Carts { get; set; }
        [JsonIgnore]
        public ICollection<WishlistEntity> Wishlist { get; set; }

    }
}
