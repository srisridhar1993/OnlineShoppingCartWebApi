using OnlineShop.IBLL;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularJsWebApi.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeApiController : ApiController
    {
        private IEmployee iemployee;
        public EmployeeApiController(IEmployee _iemployee)
        {
            iemployee = _iemployee;
        }

        [HttpPost]
        [Route("SaveEmployee")]
        public async Task<HttpResponseMessage> SaveEmployeeDetails(M_Employee emp)
        {
            try
            {
                EmployeeLogin login = new EmployeeLogin();
                await Task.Run(() =>
                {
                     login =  iemployee.SaveEmployee(emp);
                });
                return Request.CreateResponse(HttpStatusCode.OK, login);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("CheckEmployeeLogin")]
        public async Task<HttpResponseMessage> EmployeeLogin([FromBody]EmployeeLogin login)
        {
            try
            {
                EmployeeLogin employee = new OnlineShop.Model.EmployeeLogin();
                await Task.Run(() =>
                {
                    employee = iemployee.LoginEmployee(login);
                });
                return Request.CreateResponse(HttpStatusCode.Found, employee);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<HttpResponseMessage> GetAllEmployee()
        {
            try
            {
                List<M_Employee> empList = new List<M_Employee>();
                await Task.Run(() =>
                {
                    empList = iemployee.GetAllEmployee();
                });
                return Request.CreateResponse(HttpStatusCode.OK, empList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<HttpResponseMessage> GetEmployeeById(long id)
        {
            try
            {
                List<M_Employee> empList = new List<M_Employee>();
                await Task.Run(() =>
                {
                    empList = iemployee.GetEmployeebyId(id);
                });
                return Request.CreateResponse(HttpStatusCode.OK, empList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
