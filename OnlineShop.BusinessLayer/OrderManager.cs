using OnlineShop.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Model;
using OnlineShop.DataAccessLayer.Repository;

namespace OnlineShop.BusinessLayer
{
    public class OrderManager : IOrder
    {
        private IOrderDA iorder;
        public OrderManager(IOrderDA _iorder)
        {
            iorder = _iorder;
        }
        Order IOrder.GetOrderList(SearchOrder order)
        {
            try
            {
                return iorder.GetOrderList(order);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        T_OrderDetails IOrder.InsertOrderDetails(T_OrderDetails orderDet)
        {
            try
            {
                return iorder.InsertOrderDetails(orderDet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        T_Order IOrder.MakeNewOrder(T_Order order)
        {
            try
            {
                return iorder.MakeNewOrder(order);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
