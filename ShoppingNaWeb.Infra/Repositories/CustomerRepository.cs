using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using System;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Entities;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using ShoppingNaWeb.Infra.Setting;
using System.Data.SqlClient;
using System.Data;

namespace ShoppingNaWeb.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private bool _disposed = false;
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public bool DocumentExists(string document)
        {
            var flag = false;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Customer WHERE document = @document";
                    cmd.Parameters.AddWithValue("@document", document);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            flag = true;
                        }
                    }
                    cn.Close();
                }
            }
            return flag;
        }

        public Customer Get(Guid id)
        {
            Customer customer;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Customer WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            customer = new Customer();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    cn.Close();
                }
            }
            return customer;
        }

        public CustomerCommandResult Get(string username)
        {
            CustomerCommandResult resut;

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Customer WHERE username = @username";
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            resut = new CustomerCommandResult(true, "Ok", dr);
                        }
                        else
                        {
                            resut = new CustomerCommandResult(false , "Erro", null);
                        }
                    }
                    cn.Close();
                }

            }
            return resut;
        }

        public void Create(Customer customer)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {                   
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Customer (Id, Name, Document, Email, RegisterDate) " +
                                                            "VALUES (@Id, @Name, @Document, @Email, @RegisterDate)";

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = customer.Id;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 200).Value = customer.Name;
                    cmd.Parameters.Add("@Document", SqlDbType.VarChar, 17).Value = customer.Document;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = customer.Email;
                    cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime).Value = customer.RegisterDate;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Save(Customer customer)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE dbo.Customer SET Name = @Name, Document= @Document, Email = @Email " +
                        "WHERE Id = @Id";

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = customer.Id;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 200).Value = customer.Name;
                    cmd.Parameters.Add("@Document", SqlDbType.VarChar, 17).Value = customer.Document;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = customer.Email;                   

                    cmd.ExecuteNonQuery();
                }
            }          
        }    

      
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _handle.Dispose();

            _disposed = true;
        }

       
    }
}
