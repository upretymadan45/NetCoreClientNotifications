using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClientNotifications.Components
{

    [ViewComponent(Name = "ClientNotifications.Notify")]
    public class NotificationViewComponent : ViewComponent{
        public IViewComponentResult Invoke()
        {
            return View("Notification");
        }
    }
}