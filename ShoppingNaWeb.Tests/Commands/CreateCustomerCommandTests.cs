using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Inputs;

namespace ShoppingNaWeb.Tests.Commands
{
    [TestClass]
    public  class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new RegisterCustomerCommand()
            {
                FirstName = "Alipio",
                LastName = "Ferro",
                Document = "53702077049",
                Email = "alipio2@gmail.com"                
            };

            Assert.AreEqual(true, command.Valid());
        }
    }
}
