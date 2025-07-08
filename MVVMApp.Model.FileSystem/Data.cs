using System.Collections.Generic;

namespace MVVMApp.Model.FileSystem
{
    public class Data
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public class Employee : IEmployee
        {
            public string Name { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Rol { get; set; }

            public string Location { get; set; }

            public void UpdateEmail(string email)
            {
                Email = email;
            }

            public void UpdateLocation(string location)
            {
                Location = location;
            }

            public void UpdateRol(string rol)
            {
                Rol = rol;
            }
        }
    }
}