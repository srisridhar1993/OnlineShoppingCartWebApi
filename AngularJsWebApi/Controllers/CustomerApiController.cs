using OnlineShop.IBLL;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularJsWebApi.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerApiController : ApiController
    {
        private ICustomer icustomer;
        public CustomerApiController(ICustomer _icustomer)
        {
            icustomer = _icustomer;
        }
        
        [Route("SaveCustomer")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddNewCustomer([FromBody]M_Customer customer)
        {
            try
            {
                M_Customer cust = new OnlineShop.Model.M_Customer();
                await Task.Run(() =>
                {
                    cust = icustomer.AddNewCustomer(customer);
                });
                return Request.CreateResponse(HttpStatusCode.OK, cust);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("CheckCustomerLogin")]
        public async Task<HttpResponseMessage> CustomerLogin([FromBody]M_Customer login)
        {
            try
            {
                M_Customer customer = new OnlineShop.Model.M_Customer();
                await Task.Run(() =>
                {
                    customer = icustomer.CustomerLogin(login);
                });
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCustomer")]
        public async Task<HttpResponseMessage> CustomerList(long? customerId)
        {
            try
            {
                List<M_Customer> customer = new List<M_Customer>();
                await Task.Run(() =>
                {
                    customer = icustomer.GetCustomer(customerId);
                });
                if (customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new {StatusCode=HttpStatusCode.NotFound,Status= "Failed"});
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("AddNewAddress")]
        public async Task<HttpResponseMessage> AddCustomerAddress([FromBody]M_BillingAddress address)
        {
            try
            {
                M_BillingAddress customer = new OnlineShop.Model.M_BillingAddress();
                await Task.Run(() =>
                {
                    customer = icustomer.AddNewAddress(address);
                });
                if (customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { StatusCode = HttpStatusCode.NotFound, Status = "Failed" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("GetAllAddress")]
        public async Task<HttpResponseMessage> GetAllAddress([FromBody]SearchAddress address)
        {
            try
            {
                List<M_BillingAddress> customer = new List<M_BillingAddress>();
                await Task.Run(() =>
                {
                    customer = icustomer.GetAllAddress(address);
                });
                if (customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { StatusCode = HttpStatusCode.NotFound, Status = "Failed" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCountry")]
        public async Task<HttpResponseMessage> GetAllCountry(int? countryId)
        {
            try
            {
                List<M_Country> country = new List<M_Country>();
                await Task.Run(() =>
                {
                    country = icustomer.GetAllCountry(countryId);
                });
                if (country != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, country);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { StatusCode = HttpStatusCode.NotFound, Status = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetState")]
        public async Task<HttpResponseMessage> CustomerList(int? countryId,int? stateId)
        {
            try
            {
                List<M_State> state = new List<M_State>();
                await Task.Run(() =>
                {
                    state = icustomer.GetAllState(countryId, stateId);
                });
                if (state != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, state);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { StatusCode = HttpStatusCode.NotFound, Status = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
