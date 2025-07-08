using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;

using MVVMApp.Model;
using MVVMApp.Services;

using ReactiveUI;

namespace MVVMApp.ViewModel.Custom
{
    public class MainWindowViewModel : ViewModelBase, IViewModel
    {
        #region Fields

        private IModel _model;
        private ILogService _logServie;
        private ObservableCollection<IEmployeeVM> _employees;
        private Interaction<IDetailsDialogVM, Unit> _showDetailsDialog;

        #endregion Fields

        #region Properties

        public string Greeting => "Welcome to MVVM!";

        public ObservableCollection<IEmployeeVM> Employees => _employees;

        public Interaction<IDetailsDialogVM, Unit> ShowDetailsDialog => _showDetailsDialog;

        #endregion Properties

        #region Commands

        public ReactiveCommand<Unit, Unit> GetDataCommand { get; }

        public ReactiveCommand<Unit, Unit> GetDataCommandAsync { get; }

        public ReactiveCommand<Unit, Unit> ClearDataCommandAsync { get; }

        public ReactiveCommand<IEmployeeVM, Unit> ShowDetailsDialogCommand { get; }

        public ReactiveCommand<Unit, Unit> FullCollectCommand { get; }

        #endregion Commands

        #region Constructors

        public MainWindowViewModel(
            IModel model,
            ILogService logService)
        {
            _model = model;
            _logServie = logService;

            _employees = new ObservableCollection<IEmployeeVM>();
            _showDetailsDialog = new Interaction<IDetailsDialogVM, Unit>();

            GetDataCommand = ReactiveCommand.Create(GetData);
            FullCollectCommand = ReactiveCommand.Create(FullCollect);
            GetDataCommandAsync = ReactiveCommand.CreateFromTask(GetDataAsync);
            ClearDataCommandAsync = ReactiveCommand.CreateFromTask(ClearDataAsync);
            ShowDetailsDialogCommand = ReactiveCommand.CreateFromTask<IEmployeeVM>(ShowDetailsDialogAsync);
        }

        #endregion Constructors

        #region Private Methods

        private void FullCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void GetData()
        {
            _employees.DisposeSequence();
            _employees.Clear();

            var list = _model.GetAllEmployees();

            foreach (var employee in list)
            {
                _employees.Add(new EmployeeVM(employee));
            }
        }

        private Task GetDataAsync()
        {
            return Task.Run(() =>
            {
                GetData();
            });
        }

        private Task ClearDataAsync()
        {
            return Task.Run(() =>
            {
                _employees.DisposeSequence();
                _employees.Clear();
            });
        }

        private async Task ShowDetailsDialogAsync(IEmployeeVM employee)
        {
            DetailsDialogVM detailsDialogVM = new DetailsDialogVM(employee);

            _logServie.Log("ShowDetailsDialogAsync");

            await ShowDetailsDialog.Handle(detailsDialogVM);

            detailsDialogVM.Dispose();
        }

        #endregion Private Methods
    }
}