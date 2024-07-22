using MediatR;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Book
{
    public class UpdateBookByIdRequest:IRequest<BookEntity>
    {
        public int BookId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int AdminId {  get; set; }
        public int Id { get; set; }

        public UpdateBookByIdRequest(int bookId,string name,string description,int price,int discount,string author,int quantity,string image,int adminId)
        {
            BookId = bookId;
            Name = name; 
            Description = description; 
            Price = price; 
            DiscountedPrice = discount; 
            Author = author;
            Quantity = quantity;
            Image = image;
            AdminId = adminId;
        }
    }
}
