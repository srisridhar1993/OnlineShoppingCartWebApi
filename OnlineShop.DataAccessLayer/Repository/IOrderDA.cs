using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccessLayer.Repository
{
    public interface IOrderDA
    {
        T_Order MakeNewOrder(T_Order order);
        T_OrderDetails InsertOrderDetails(T_OrderDetails orderDet);
        Order GetOrderList(SearchOrder order);
    }
}
