using Microsoft.UI.Xaml;

namespace HandyShell
{
    public sealed partial class MainWindow : Window
    {
        internal static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}
