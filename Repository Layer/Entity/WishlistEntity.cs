using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class WishlistEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishlistId { get; set; }
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public UserEntity? User { get; set; }
        [ForeignKey("Book")]
        public int BookId {  get; set; }
        public BookEntity? Book { get; set; }
    }
}
