using Microsoft.UI.Xaml;
using SettingsUI.Helpers;

namespace HandyShell
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Title = "HandyShell";
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(m_window);
            PInvokeHelper.SetWindowSize(hwnd, 900, 750);
            m_window.Activate();
        }

        private Window m_window;
    }
}
