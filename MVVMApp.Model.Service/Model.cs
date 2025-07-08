using System.Collections.Generic;

namespace MVVMApp.Model.Web
{
    public class Model : IModel
    {
        public List<IEmployee> GetAllEmployees()
        {
            var employees = new List<IEmployee>
            {
                new Employee()
                {
                    Name = "Bob",
                    LastName = "Sponge",
                    Email = "bob.sponge@pablo.com",
                    Rol = "Fry cook/waiter",
                    Location = "Under the sea"
                },
                new Employee()
                {
                   Name = "Dwight",
                   LastName = "Schrute",
                   Email = "dwight.schrute@pablo.com",
                   Rol = "Officer Assistant",
                   Location = "The Office"
                },
                new Employee()
                {
                    Name = "Aaron",
                    LastName = "Abeyta",
                    Email = "aaron.abeyta@pablo.com",
                    Rol = "The Boss",
                    Location = "California"
                }
            };
            return employees;
        }
    }
}
