using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingNaWeb.Shared.Commands
{
   public interface ICommand
    {
        bool Valid();
    }
}
