using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using System;
using ShoppingNaWeb.Domain.ShoppingContext.Entities;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Results;
using ShoppingNaWeb.Infra.Setting;
using System.Data.SqlClient;
using System.Data;

namespace ShoppingNaWeb.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private bool _disposed = false;
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);


        public void Create(Order order)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Order (Id, CustomerId, Number, Discount, DeliveryFee, CreateDate, StatusId) " +
                                                            "VALUES (@Id, @CustomerId, @Number, @Discount, @DeliveryFee, @CreateDate, @StatusId)";

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = order.Id;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.NVarChar).Value = order.Customer.Id;
                    cmd.Parameters.Add("@Number", SqlDbType.VarChar, 17).Value = order.Number;
                    cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = order.Discount;
                    cmd.Parameters.Add("@DeliveryFee", SqlDbType.Decimal).Value = order.DeliveryFee;
                    cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = order.CreateDate;
                    cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = order.Status;


                    cmd.ExecuteNonQuery();
                }

                #region 

                var dt = new DataTable();
                dt.Columns.Add("IdOrder");
                dt.Columns.Add("IdProdut");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");

                foreach (var item in order.Items)
                {
                    dt.Rows.Add(item.Id, item.Product.Id, item.Quantity, item.Price);
                }

                var transaction = cn.BeginTransaction();

                using (var sqlBulk = new SqlBulkCopy(cn, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    sqlBulk.DestinationTableName = "OrderItem";
                    sqlBulk.WriteToServer(dt);
                }

                #endregion

            }
        }

        public void Save(Order order)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE dbo.Order SET Discount = @Discount, DeliveryFee= @DeliveryFee, StatusId = @StatusId " +
                        "WHERE Id = @Id AND Number = @Number";                        

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = order.Id;                  
                    cmd.Parameters.Add("@Number", SqlDbType.VarChar, 17).Value = order.Number;
                    cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = order.Discount;
                    cmd.Parameters.Add("@DeliveryFee", SqlDbType.Decimal).Value = order.DeliveryFee;                    
                    cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = order.Status;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrderCommandResult Get(Guid id)
        {
            OrderCommandResult resut;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Order WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            resut = new OrderCommandResult(true, "Ok", dr);
                        }
                        else
                        {
                            resut = new OrderCommandResult(false, "Erro", null);
                        }
                    }
                    cn.Close();
                }

            }
            return resut;
        }

        public Order GetById(Guid id)
        {
            Order resut;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Order WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            resut = new Order();
                        }
                        else
                        {
                            resut = null;
                        }
                    }
                    cn.Close();
                }

            }
            return resut;
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
