using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace HandyShell
{
    public static class Alert
    {
        public static async void InfoAsync(string content, string title = "Info")
        {
            var dialog = new ContentDialog
            {
                Title = title,
                PrimaryButtonText = "",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = MainWindow.Instance.Content.XamlRoot,
                Content = content
            };
            await dialog.ShowAsync();
        }

        public static async Task<bool> ChooseAsync(string content, string title = "")
        {
            var dialog = new ContentDialog
            {
                Title = title,
                PrimaryButtonText = "Ok",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Primary,
                XamlRoot = MainWindow.Instance.Content.XamlRoot,
                Content = content
            };
            var result = await dialog.ShowAsync();
            return result == ContentDialogResult.Primary;
        }
    }
}
