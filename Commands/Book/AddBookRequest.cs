using MediatR;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Book
{
    public class AddBookRequest : IRequest<BookEntity>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int AdminId { get; set; }

        public AddBookRequest(string name, string description, int price, int discountedPrice, string author, int quantity, string image, int adminId)
        {
            Name = name;
            Description = description;
            Price = price;
            DiscountedPrice = discountedPrice;
            Author = author;
            Quantity = quantity;
            Image = image;
            AdminId = adminId;
        }
    }
}
