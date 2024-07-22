using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class OrdersEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public UserEntity? User { get; set; }
        [ForeignKey("Book")]
        public int BookId {  get; set; }
        public BookEntity? Book { get; set; }
        [Required]
        public int BookQuantity { get; set; }
        [ForeignKey("CustomerDetail")]
        public int CustomerDetailId { get; set;}
        public CustomerDetailsEntity? CustomerDetail { get; set; }
        [Required]
        public double TotalPrice {  get; set; }
    }
}
