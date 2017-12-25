using static ClientNotifications.Helpers.NotificationHelper;

namespace ClientNotifications
{
    public interface IClientNotification
    {
        void AddToastNotification(string message, NotificationType type, ToastNotificationOption options);
        void AddSweetNotification(string title, string detail, NotificationType type);
    }
}