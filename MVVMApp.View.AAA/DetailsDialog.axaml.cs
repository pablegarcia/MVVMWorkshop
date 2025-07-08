using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using MVVMApp.ViewModel;

namespace MVVMApp.View.AAA
{
    public partial class DetailsDialog : Window
    {
        public DetailsDialog()
        {
            InitializeComponent();
        }

        public DetailsDialog(IDetailsDialogVM viewModel)
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