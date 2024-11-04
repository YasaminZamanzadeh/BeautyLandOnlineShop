using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserOnline
{
    public  interface IGuestUserOnlineService
    {
        void Connected(string guestUserId);
        void Disconnected(string guestUserId);
        int Count();
    }
}
