using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IBLL
{
    public interface IOrder
    {
        T_Order MakeNewOrder(T_Order order);
        T_OrderDetails InsertOrderDetails(T_OrderDetails orderDet);
        Order GetOrderList(SearchOrder order);
    }
}
