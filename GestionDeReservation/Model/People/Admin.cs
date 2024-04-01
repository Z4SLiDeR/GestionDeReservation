using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.People
{
    public class Admin : User
    {
        private AdminType _role;
        private static List<Admin> _admins = new List<Admin>();
        public Admin(int id, string lastName, string firstName, string email, DateOnly birthday, string phoneNumber, string gender, string password, AdminType role,Address address) 
            : base(id, lastName, firstName, email, birthday, phoneNumber, gender,password,address)
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
        // Méthode pour ajouter un nouvel administrateur
        public static void AddNewAdmin(Admin admin, AdminType role)
        {
            admin.Role = role; // Définir le rôle de l'administrateur
            _admins.Add(admin);
        }

        // Méthode pour retirer un administrateur
        public static void RemoveAdmin(Admin admin, AdminType role)
        {
            admin.Role = role; //Enlever le rôle d'admin    
            _admins.Remove(admin);
        }
        #endregion
    }
}
