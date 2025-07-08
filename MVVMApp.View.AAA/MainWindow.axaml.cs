using System.Reactive;
using System.Threading.Tasks;

using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using MVVMApp.ViewModel;

using ReactiveUI;

namespace MVVMApp.View.AAA
{
    public partial class MainWindow : ReactiveWindow<IViewModel>, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;

            this.WhenActivated(
                d => d(ViewModel!.ShowDetailsDialog.RegisterHandler(DoShowDialogAsync)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task DoShowDialogAsync(
            IInteractionContext<IDetailsDialogVM, Unit> context)
        {
            var dialog = new DetailsDialog(context.Input);

            var result = await dialog.ShowDialog<Unit>(this);
            context.SetOutput(result);
        }
    }
}