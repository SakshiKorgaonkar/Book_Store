﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
    public class LoginML
    {
        [EmailAddress]
        public string Email {  get; set; }
        public string Password { get; set; }
    }
}
