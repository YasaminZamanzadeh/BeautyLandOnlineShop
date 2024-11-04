using BeautyLand.Domain.Order;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Orders.GetOrder
{
    public interface IOrderService
    {
        int CreateOrder(int basketId, int addressId,  PaymentMethod paymentMethod);
    }
}
