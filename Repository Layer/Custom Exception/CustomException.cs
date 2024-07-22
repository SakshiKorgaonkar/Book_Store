using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Custom_Exception
{
    public class CustomException :Exception
    {
        public CustomException(string message):base(message) { }
    }
}
