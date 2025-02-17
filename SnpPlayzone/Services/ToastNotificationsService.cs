using CommunityToolkit.WinUI.Notifications;

using SnpPlayzone.Contracts.Services;

using Windows.UI.Notifications;

namespace SnpPlayzone.Services;

public partial class ToastNotificationsService : IToastNotificationsService
{
    public ToastNotificationsService()
    {
    }

    public void ShowToastNotification(ToastNotification toastNotification)
    {
        ToastNotificationManagerCompat.CreateToastNotifier().Show(toastNotification);
    }
}
