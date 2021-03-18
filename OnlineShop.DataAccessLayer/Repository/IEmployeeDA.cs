using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccessLayer.Repository
{
    public interface IEmployeeDA
    {
        EmployeeLogin SaveEmployeedetails(M_Employee employee);
        EmployeeLogin LoginEmployee(EmployeeLogin employee);
        List<M_Employee> GetAllEmployee();
        List<M_Employee> GetEmployeebyId(long empId);
    }
}
