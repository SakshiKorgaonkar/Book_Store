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
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("BookEntity")]
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
        [Required]
        public int BookQuantity { get; set; }
        [ForeignKey("UserEntity")]
        public int UserId {  get; set; }
        public UserEntity User { get; set; }
        [Required]
        public int TotalPrice {  get; set; }
    }
}
