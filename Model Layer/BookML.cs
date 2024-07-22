using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
    public class BookML
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
