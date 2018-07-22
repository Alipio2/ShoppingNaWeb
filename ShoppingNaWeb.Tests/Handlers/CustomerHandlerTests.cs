using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Handlers;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Inputs;
using ShoppingNaWeb.Tests.Repository;

namespace ShoppingNaWeb.Tests.Handlers
{
    [TestClass]
   public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new RegisterCustomerCommand()
            {
                FirstName = "Alipio",
                LastName = "Ferro",
                Document = "53702077049",
                Email = "alipio2@gmail.com"
            };


            var handler = new CustomerCommandHandler(new FakeCustomerRepository());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);           
        }
    }
}
