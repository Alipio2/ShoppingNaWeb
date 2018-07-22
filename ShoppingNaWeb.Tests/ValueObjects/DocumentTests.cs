using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingNaWeb.Domain.ShoppingContext.ValueObjects;

namespace ShoppingNaWeb.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("53702077049");
            invalidDocument = new Document("101010101010");
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.Validate("53702077049"));
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.Validate("101010101010"));           
        }

        
    }
}
