using OnlineShop.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OnlineShop.DataAccessLayer
{
    public class OrderDA : IOrderDA
    {
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShopingEntities"].ToString());
        SqlCommand cmd;
        Order IOrderDA.GetOrderList(SearchOrder order)
        {
            DataSet dt = new DataSet();
            Order orderDet = new Order();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspCustomerOrders", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@MobileNo", order.MobileNo);
            cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
            cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            orderDet.OrderMasters = ExtensionMethods.ConvertToListOf<OrderMaster>(dt.Tables[0]);
            orderDet.OrderDetail = ExtensionMethods.ConvertToListOf<OrderDetails>(dt.Tables[1]);
            return orderDet;
        }

        T_OrderDetails IOrderDA.InsertOrderDetails(T_OrderDetails orderDet)
        {
            DataTable dt = new DataTable();
            T_OrderDetails ord = new T_OrderDetails();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspInsertOrderDetails", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", orderDet.OrderId);
            cmd.Parameters.AddWithValue("@ProductId", orderDet.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", orderDet.Quantity);
            cmd.Parameters.AddWithValue("@TotalPrice", orderDet.TotalPrice);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            ord = ExtensionMethods.ConvertToListOf<T_OrderDetails>(dt).FirstOrDefault();
            return ord;
        }

        T_Order IOrderDA.MakeNewOrder(T_Order order)
        {
            DataTable dt = new DataTable();
            T_Order ord = new T_Order();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspInsertOrder", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
            cmd.Parameters.AddWithValue("@ShippingAddressId", order.ShippingAddressId);
            cmd.Parameters.AddWithValue("@BillingAddressId", order.BillingAddressId);
            cmd.Parameters.AddWithValue("@Amount", order.Amount);
            cmd.Parameters.AddWithValue("@PaymentTypeId", order.PaymentTypeId);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            ord = ExtensionMethods.ConvertToListOf<T_Order>(dt).FirstOrDefault();
            return ord;
        }
    }
}
