using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.People
{
    public class Admin : User
    {
        private AdminType _role;
        public Admin(string lastName, string firstName, string email, DateOnly birthday, string phoneNumber, string gender, string password, AdminType role,Address address) 
            : base(lastName, firstName, email, birthday, phoneNumber, gender,password,address)
        {
            Role = role;
        }
        public enum AdminType
        {
            Direction,
            Employé
        }

        #region GetAndSet
        public AdminType Role
        {
            get => _role;
            set
            {
                _role = value;
            }
        }
        #endregion

        #region Methodes
        #endregion
    }
}
