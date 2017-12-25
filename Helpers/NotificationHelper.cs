using System.Collections.Generic;

namespace ClientNotifications.Helpers
{
    public class NotificationHelper
    {
        public enum NotificationType{
            error,
            success,
            warning,
            info
        }

        public enum NotificationPosition{
            topRight,
            topLeft,
            bottomLeft,
            bottomRight
        }

        public Dictionary<NotificationPosition,string> position(){
            var positions = new Dictionary<NotificationPosition,string>();

            positions.Add(NotificationPosition.topRight,"toast-top-right");
            positions.Add(NotificationPosition.topLeft,"toast-top-left");
            positions.Add(NotificationPosition.bottomRight,"toast-bottom-right");
            positions.Add(NotificationPosition.bottomLeft,"toast-bottom-left");

            return positions;
        } 
    }
}