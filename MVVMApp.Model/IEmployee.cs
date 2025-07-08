namespace MVVMApp.Model
{
    public interface IEmployee
    {
        #region Properties

        string Name { get; }

        string LastName { get; }

        string Email { get; set; }

        string Rol { get; }

        string Location { get; }

        #endregion Properties

        #region Methods

        void UpdateLocation(string location);

        void UpdateRol(string rol);

        void UpdateEmail(string email);

        #endregion Methods
    }
}