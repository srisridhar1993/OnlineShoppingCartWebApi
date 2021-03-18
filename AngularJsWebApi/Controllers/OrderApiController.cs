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
    [RoutePrefix("api/Order")]
    public class OrderApiController : ApiController
    {
        private IOrder iorder;
        public OrderApiController(IOrder _iorder)
        {
            iorder = _iorder;
        }
        [HttpPost]
        [Route("MakeNewOrder")]
        public async Task<HttpResponseMessage> MakeNewOrder(T_Order order)
        {
            T_Order result = new T_Order();
            try
            {
                await Task.Run(() =>
                {
                    result = iorder.MakeNewOrder(order);
                });
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("AddOrderDetails")]
        public async Task<HttpResponseMessage> AddOrderDetails(T_OrderDetails order)
        {
            T_OrderDetails result = new T_OrderDetails();
            try
            {
                await Task.Run(() =>
                {
                    result = iorder.InsertOrderDetails(order);
                });
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("GetOrderList")]
        public async Task<HttpResponseMessage> GetOrderList(SearchOrder order)
        {
            Order result = new Order();
            try
            {
                await Task.Run(() =>
                {
                    result = iorder.GetOrderList(order);
                });
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
