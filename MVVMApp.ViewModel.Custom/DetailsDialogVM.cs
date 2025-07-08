using System.Reactive;

using ReactiveUI;

namespace MVVMApp.ViewModel.Custom
{
    public class DetailsDialogVM : ViewModelBase, IDetailsDialogVM, IDisposable
    {
        #region Fields

        private IEmployeeVM _employee;
        private int _heartbeats;

        #endregion Fields

        #region Properties

        public string Name => _employee.Name;

        public string LastName => _employee.LastName;

        public string Email => _employee.Email;

        public string Rol => _employee.Rol;

        public string Location => _employee.Location;

        public int Heartbeats
        {
            get => _heartbeats;
            set
            {
                if (value != _heartbeats)
                {
                    _heartbeats = value;

                    this.RaisePropertyChanged(nameof(Heartbeats));
                }
            }
        }

        #endregion Properties

        #region Commands

        public ReactiveCommand<Unit, Unit> ClearHeartbeatsCommand { get; }

        #endregion Commands

        #region Constructors

        public DetailsDialogVM(
            IEmployeeVM employee)
        {
            _employee = employee;
            _employee.Heartbeat += OnHeartbeatReceived;

            ClearHeartbeatsCommand = ReactiveCommand.Create(ClearHeartbeats);
        }

        #endregion Constructors

        #region IDisposable

        public void Dispose()
        {
            _heartbeats = 0;
            _employee.Heartbeat -= OnHeartbeatReceived;

            ClearHeartbeatsCommand.Dispose();
        }

        #endregion IDisposable

        #region Private Methods

        private void OnHeartbeatReceived(DateTime time)
        {
            System.Diagnostics.Debug.WriteLine(
                "[DetailsDialogVM] Heartbeat received for {0} from thread {1}",
                Name,
                Thread.CurrentThread.ManagedThreadId);

            Heartbeats++;
        }

        private void ClearHeartbeats()
        {
            System.Diagnostics.Debug.WriteLine(
                "[DetailsDialogVM] Clear Heartbeats from thread {0}",
                Thread.CurrentThread.ManagedThreadId);

            Heartbeats = 0;
        }

        #endregion Private Methods
    }
}