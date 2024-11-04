using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Baskets.Basket
{
    public interface IBasketService
    {
        BasketDto GetorSetBasket(string buyerId);
        BasketDto GetBasket(string userId);
        void CreateBasketItem(int basketId, int itemId, int quantity = 1);
        bool DeleteBasketItem(int itemId);
        bool GetorSetQuantities(int itemId, int quantity);
        void TransferBasket(string buyerId, string userId);
    }

}
