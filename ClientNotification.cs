using ClientNotifications.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static ClientNotifications.Helpers.NotificationHelper;

namespace ClientNotifications
{
    public class ClientNotification : IClientNotification
    {
        private IHttpContextAccessor _httpContextAccessor;
        private HttpContext _httpContext;
        private ITempDataDictionaryFactory _factory;
        private ITempDataDictionary _tempData;
        public ClientNotification(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = _httpContextAccessor.HttpContext;
            _factory = _httpContext.RequestServices.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;
            _tempData = _factory.GetTempData(_httpContext);
        }

        public void AddSweetNotification(string title, string detail, NotificationType type)
        {
            var msg = "swal('"+title+"', '"+detail+"', '"+type+"')";

            _tempData["swalNotification"]=msg;
        }

        public void AddToastNotification(string message, NotificationType type, ToastNotificationOption options)
        {
            var positions = new NotificationHelper().position();

            var JsonSerializerSettings= new JsonSerializerSettings{
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if(options==null){
                _tempData["options"]=JsonConvert
                        .SerializeObject(new ToastNotificationOption(),JsonSerializerSettings);                                
            } else {
                _tempData["options"]=JsonConvert
                        .SerializeObject(options,JsonSerializerSettings);                                
            }

            var msg = "toastr."+type+"('"+message+"')";
            _tempData["notification"]=msg;
        }
    }
}