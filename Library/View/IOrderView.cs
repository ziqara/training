using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public interface IOrderView
    {
        void ShowOrderInfo(Order order);
        Order GetOrderInfo();
    }
}
