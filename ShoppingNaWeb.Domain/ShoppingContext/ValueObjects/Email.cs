using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingNaWeb.Domain.ShoppingContext.ValueObjects
{
   public class Email
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;           
        }
    }
}
