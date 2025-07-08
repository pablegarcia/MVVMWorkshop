using System.Reactive;

using ReactiveUI;

namespace MVVMApp.ViewModel
{
    public interface IViewModel
    {
        ReactiveCommand<Unit, Unit> GetDataCommand { get; }

        ReactiveCommand<Unit, Unit> GetDataCommandAsync { get; }

        Interaction<IDetailsDialogVM, Unit> ShowDetailsDialog { get; }
    }
}