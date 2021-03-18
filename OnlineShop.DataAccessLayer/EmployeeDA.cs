using OnlineShop.DataAccessLayer.Repository;
using OnlineShop.Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace OnlineShop.DataAccessLayer
{
    public class EmployeeDA: IEmployeeDA
    {
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShopingEntities"].ToString());
        SqlCommand cmd;
        EmployeeLogin IEmployeeDA.SaveEmployeedetails(M_Employee employee)
        {
            DataTable dt = new DataTable();
            EmployeeLogin empResp = new EmployeeLogin();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspInsertNewEmployee", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FistName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@UserName", employee.UserName);
            cmd.Parameters.AddWithValue("@Password", employee.Password);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Mobile", employee.Mobile);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@CreatedBy", 1);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            empResp = ExtensionMethods.ConvertToListOf<EmployeeLogin>(dt)[0];
            return empResp;

        }

        EmployeeLogin IEmployeeDA.LoginEmployee(EmployeeLogin employee)
        {
            DataTable dt = new DataTable();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspCheckEmployeeLogin", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", employee.Username);
            cmd.Parameters.AddWithValue("@Password", employee.Password);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            return ExtensionMethods.ConvertToListOf<EmployeeLogin>(dt)[0];
        }

        List<M_Employee> IEmployeeDA.GetAllEmployee()
        {
            List<M_Employee> empList = new List<M_Employee>();
            DataTable dt = new DataTable();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspSelectAllEmployee", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", null);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            empList = ExtensionMethods.ConvertToListOf<M_Employee>(dt);
            return empList;
        }

        List<M_Employee> IEmployeeDA.GetEmployeebyId(long empId)
        {
            List<M_Employee> empList = new List<M_Employee>();
            DataTable dt = new DataTable();
            if (connString.State == ConnectionState.Closed)
                connString.Open();
            cmd = new SqlCommand("uspSelectAllEmployee", connString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", empId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sda.Dispose();
            connString.Close();
            empList = ExtensionMethods.ConvertToListOf<M_Employee>(dt);
            return empList;
        }
    }
}
