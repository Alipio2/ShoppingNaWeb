using ShoppingNaWeb.Domain.ShoppingContext.ValueObjects;
using ShoppingNaWeb.Shared.Entities;
using ShoppingNaWeb.Shared.Validation;
using System;

namespace ShoppingNaWeb.Domain.ShoppingContext.Entities
{
    public class Customer : Entity
    {
        #region Atributos
        public Name Name { get; private set; }        
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public DateTime? RegisterDate { get; private set; }
        #endregion

        #region Metodos
        public Customer()
        {
                
        }
        public Customer(Name name, Email email, Document document)
        {
            Name = name;
            RegisterDate = null;
            Email = email;
            Document = document;

            AssertionConcern.AssertArgumentNotEmpty(document.Number, "O Cpf não pode ser nulo.");
            AssertionConcern.AssertArgumentNotEmpty(name.ToString(), "O Nome não pode ser nulo.");
        }

        public void Update(Name name, DateTime registerDate)
        {
            Name = name;
            RegisterDate = registerDate;
        }        
        #endregion
    }
}
