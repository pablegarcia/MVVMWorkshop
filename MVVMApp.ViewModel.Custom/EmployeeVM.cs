using System.Reactive.Linq;

using MVVMApp.Model;

using ReactiveUI;

namespace MVVMApp.ViewModel.Custom
{
    public class EmployeeVM : ViewModelBase, IEmployeeVM, IDisposable
    {
        #region Fields

        private IEmployee _employee;
        private IDisposable _heartbeat;

        #endregion Fields

        #region Properties

        public string Name => _employee.Name;

        public string LastName => _employee.LastName;

        public string Email
        {
            get => _employee.Email;
            set
            {
                if (value != _employee.Email)
                {
                    _employee.UpdateEmail(value);

                    this.RaisePropertyChanged(nameof(Email));
                }
            }
        }

        public string Rol
        {
            get => _employee.Rol;
            set
            {
                if (value != _employee.Rol)
                {
                    _employee.UpdateRol(value);

                    this.RaisePropertyChanged(nameof(Rol));
                }
            }
        }

        public string Location
        {
            get => _employee.Location;
            set
            {
                if (value != _employee.Location)
                {
                    _employee.UpdateLocation(value);

                    this.RaisePropertyChanged(nameof(Location));
                }
            }
        }

        #endregion Properties

        #region Events

        public event Action<DateTime> Heartbeat;

        #endregion Events

        #region Constructors

        public EmployeeVM(IEmployee employee)
        {
            _employee = employee;

            StartHeartbeat();
        }

        #endregion Constructors

        public void Dispose()
        {
            _heartbeat?.Dispose();
        }

        #region Private Methods

        private void StartHeartbeat()
        {
            _heartbeat = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Subscribe(
                    x =>
                    {
                        Heartbeat?.Invoke(DateTime.Now);
                    });
        }

        #endregion Private Methods
    }
}