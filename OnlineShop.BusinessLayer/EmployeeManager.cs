using OnlineShop.IBLL;
using OnlineShop.Model;
using OnlineShop.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DataAccessLayer.Repository;

namespace OnlineShop.BusinessLayer
{
    
    public class EmployeeManager : IEmployee
    {
        IEmployeeDA iempDa;
        public EmployeeManager(IEmployeeDA _iempDa)
        {
            iempDa = _iempDa;
        }
        //OnlineShopingModel dbContext = new OnlineShopingModel();
        //EmployeeDA empDa = new EmployeeDA();

        public List<M_Employee> GetAllEmployee()
        {
            try
            {
                return iempDa.GetAllEmployee();
            }
            catch (Exception)
            {
                return new List<M_Employee>();
            }
        }

        public List<M_Employee> GetEmployeebyId(long empId)
        {
            try
            {
                return iempDa.GetEmployeebyId(empId);
            }
            catch (Exception)
            {
                return new List<M_Employee>();
            }
        }

        public EmployeeLogin LoginEmployee(EmployeeLogin login)
        {
            try
            {
                return iempDa.LoginEmployee(login);
            }
            catch (Exception)
            {
                return new EmployeeLogin();
            }
        }

        public EmployeeLogin SaveEmployee(M_Employee employee)
        {
            EmployeeLogin obj = new EmployeeLogin();
            obj=iempDa.SaveEmployeedetails(employee);
            return obj;
        }
    }
}
