using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
    public class ResponseML
    {
        public string Message { get; set; }
        public object? Data { get; set; }
        public bool Status { get; set; }

    }
}
