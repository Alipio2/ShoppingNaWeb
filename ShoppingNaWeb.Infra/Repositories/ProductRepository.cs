using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using System;
using ShoppingNaWeb.Domain.ShoppingContext.Entities;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using ShoppingNaWeb.Infra.Setting;
using System.Data.SqlClient;
using System.Data;

namespace ShoppingNaWeb.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private bool _disposed = false;
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public Product Get(Guid id)
        {
            Product produtc;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Product WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            produtc = new Product();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    cn.Close();
                }
            }
            return produtc;
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
