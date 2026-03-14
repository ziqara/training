using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Orders
{
    public interface IOrdersRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int orderNumber);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderNumber);
        List<string> GetAvailableStatuses();
        List<PickUpPoint> GetPickUpPoints();
        List<Library.Tovar.Tovar> GetAvailableProducts();
        List<Library.User.User> GetUsers();
    }
}