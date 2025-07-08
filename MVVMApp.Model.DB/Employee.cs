using System;

namespace MVVMApp.Model.DB
{
    [Serializable]
    public class Employee : IEmployee
    {
        public virtual uint Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Rol { get; set; }

        public virtual string Location { get; set; }

        public virtual void UpdateEmail(string email)
        {
            Email = email;
        }

        public virtual void UpdateLocation(string location)
        {
            Location = location;
        }

        public virtual void UpdateRol(string rol)
        {
            Rol = rol;
        }
    }
}