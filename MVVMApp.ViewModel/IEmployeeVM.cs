namespace MVVMApp.ViewModel
{
    public interface IEmployeeVM
    {
        string Name { get; }

        string LastName { get; }

        string Email { get; set; }

        string Rol { get; set; }

        string Location { get; set; }

        event Action<DateTime> Heartbeat;
    }
}