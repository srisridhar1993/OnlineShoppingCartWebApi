using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Model;

namespace OnlineShop.IBLL
{
    public interface IEmployee
    {
        EmployeeLogin SaveEmployee(M_Employee employee);
        EmployeeLogin LoginEmployee(EmployeeLogin login);
        List<M_Employee> GetEmployeebyId(long empId);
        List<M_Employee> GetAllEmployee();
    }
}
