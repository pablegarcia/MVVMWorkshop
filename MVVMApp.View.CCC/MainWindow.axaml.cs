using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using MVVMApp.ViewModel;

namespace MVVMApp.View.CCC
{
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}