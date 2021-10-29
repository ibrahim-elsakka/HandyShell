using HandyShell.Menu;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace HandyShell
{
    public sealed partial class ShellPage : Page
    {
        private MenuPageViewModel _viewModel;
        public ShellPage()
        {
            NavigationCacheMode = NavigationCacheMode.Required;
            InitializeComponent();
            _viewModel = new MenuPageViewModel(OnException);
            _ = _viewModel.LoadAsync();
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var item = _viewModel.New();
            CommandList.SelectedItem = item;
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (CommandList.SelectedItem is MenuItem item)
            {
                await _viewModel.SaveAsync(item);
                //TODO 
                //CommandList.SelectedItem = item;
            }
            else
            {
                Alert.InfoAsync("no selected item");
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CommandList.SelectedItem is MenuItem item)
            {
                await _viewModel.DeleteAsync(item);
            }
            else
            {
                Alert.InfoAsync("no selected item");
            }
        }

        private void OnException(Exception e, string message)
        {
            Alert.InfoAsync(message ?? e.Message, "Error");
        }

        private async void OpenExe_Click(object sender, RoutedEventArgs e)
        {
            var main = MainWindow.Instance;
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(main);
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add("*");
            picker.ViewMode = PickerViewMode.Thumbnail;
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                txtApp.Text = $"\"{file.Path}\"";
            }
        }
        private async void OpenIcon_Click(object sender, RoutedEventArgs e)
        {
            var main = MainWindow.Instance;
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(main);
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".ico");
            picker.FileTypeFilter.Add(".icon");
            picker.ViewMode = PickerViewMode.Thumbnail;
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                txtIcon.Text = $"\"{file.Path}\"";
            }
        }
    }
}
