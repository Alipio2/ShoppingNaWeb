﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingNaWeb.Domain.ShoppingContext.ValueObjects
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }   
}
