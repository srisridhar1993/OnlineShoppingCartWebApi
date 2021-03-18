using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OnlineShop.DataAccessLayer.Repository
{
    public class CustomerDA : ICustomerDA
    {
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShopingEntities"].ToString());
        SqlCommand cmd;
        M_Customer ICustomerDA.AddNewCustomer(M_Customer customer)
        {
            DataTable dt = new DataTable();
            M_Customer cust = new M_Customer();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspInsertCustomer", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@Password", customer.Password);
            cmd.Parameters.AddWithValue("@EmailId", customer.EmailId);
            cmd.Parameters.AddWithValue("@MobileNo", customer.MobileNo);
            cmd.Parameters.AddWithValue("@ProfileImage", customer.ProfileImage);
           
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            cust = ExtensionMethods.ConvertToListOf<M_Customer>(dt).FirstOrDefault();
            return cust;
        }

        M_Customer ICustomerDA.CustomerLogin(M_Customer customer)
        {
            DataTable dt = new DataTable();
            M_Customer cust = new M_Customer();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspCheckCustomerLogin", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Password", customer.Password);
            cmd.Parameters.AddWithValue("@EmailId", customer.EmailId);
            cmd.Parameters.AddWithValue("@MobileNo", customer.MobileNo);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            cust = ExtensionMethods.ConvertToListOf<M_Customer>(dt).FirstOrDefault();
            return cust;
        }

        List<M_Customer> ICustomerDA.GetCustomer(long? customerId)
        {
            DataTable dt = new DataTable();
            List<M_Customer> cust = new List<M_Customer>();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspGetCustomerList", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", customerId);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            cust = ExtensionMethods.ConvertToListOf<M_Customer>(dt);
            return cust;
        }

        M_BillingAddress ICustomerDA.AddNewAddress(M_BillingAddress address)
        {
            //M_BillingAddress result = new M_BillingAddress();
            try
            {
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspInsertUpdateAddress", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", address.CustomerId);
                cmd.Parameters.AddWithValue("@BillingAddressId", address.BillingAddressId);
                cmd.Parameters.AddWithValue("@Name", address.Name);
                cmd.Parameters.AddWithValue("@Address1", address.Address1);
                cmd.Parameters.AddWithValue("@Address2", address.Address2);
                cmd.Parameters.AddWithValue("@LandMark", address.LandMark);
                cmd.Parameters.AddWithValue("@ContactNo", address.ContactNo);
                cmd.Parameters.AddWithValue("@Pincode", address.Pincode);
                cmd.Parameters.AddWithValue("@StateId", address.StateId);
                cmd.Parameters.AddWithValue("@CountryId", address.CountryId);
                cmd.Parameters.AddWithValue("@Latitude", address.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", address.Longitude);
                cmd.Parameters.AddWithValue("@AddressType", address.AddressType);
                cmd.Parameters.AddWithValue("@IsDefault", address.IsDefault);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                return ExtensionMethods.ConvertToListOf<M_BillingAddress>(dt).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connString.Close();
            }
        }

        List<M_BillingAddress> ICustomerDA.GetAllAddress(SearchAddress address)
        {
            try
            {
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspGetCustomerAddress", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", address.CustomerId);
                cmd.Parameters.AddWithValue("@AddressId", address.AddressId);
                cmd.Parameters.AddWithValue("@Pincode", "");
                cmd.Parameters.AddWithValue("@AddressType", address.AddressType);
                cmd.Parameters.AddWithValue("@IsDefault", address.IsDefault);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                return ExtensionMethods.ConvertToListOf<M_BillingAddress>(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connString.Close();
            }
        }

        List<M_Country> ICustomerDA.GetAllCountry(int? countryId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspAllCountry", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryId", countryId);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                return ExtensionMethods.ConvertToListOf<M_Country>(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        List<M_State> ICustomerDA.GetAllState(int? countryId, int? stateId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspAllState", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryId", countryId);
                cmd.Parameters.AddWithValue("@StateId", stateId);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                return ExtensionMethods.ConvertToListOf<M_State>(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
