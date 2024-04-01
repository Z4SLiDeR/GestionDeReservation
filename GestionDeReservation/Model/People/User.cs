using System.Globalization;
using System.Text.RegularExpressions;

namespace GestionDeReservation.Model.People
{
    public class User
    {
        #region Attributs
        private int _id;
        private string _lastName;
        private string _firstName;
        private string _email;
        private DateOnly _birthday;
        private string _phoneNumber;
        private string _gender;
        private Address _address;

        protected private string _password;

        private static int totalUser;

        //constante
        private static int MIN_CHAR_PASSWORD = 8;
        private static int MAX_CHAR_PASSWORD = 20;
        private static int KEY_HASH_PASSWORD = 5;
        protected const string DEFAULT_PASSWD = "Password01"; //password par défaut
        #endregion

        #region Constructeur
        public User(int id,string lastName, string firstName, string email, DateOnly birthday, string phoneNumber, string gender, string password, Address address)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Password = password;
            Address = address;
            totalUser++;

        }
        #endregion

        #region GetAndSet
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (CheckEntryName(value))
                {
                    _lastName = value;
                }
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (CheckEntryName(value))
                {
                    _firstName = value;
                }
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (CheckEMail(value))
                {
                    _email = value;
                }
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (CheckMobilePhoneNumber(value))
                {
                    _phoneNumber = value;
                }
            }
        }
        public DateOnly Birthday
        {
            get => _birthday;

            set
            {
                if (CheckCorrectBirthday(value))
                {
                    _birthday = value;
                }
            }
        } //TODO Vérification de date rentrée
        public string Gender
        {
            get => _gender;

            set
            {
                if (CheckGender(value))
                {
                    _gender = value;
                }
                else
                {
                    _gender = "Non défini";
                }
            }
        } // Vérification de genre
        protected string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (CheckPassword(value, this.FirstName, this.LastName))
                    _password = value;
            }
        }

        public Address Address
        {
            get => _address;
            set
            {
                _address = value;
            }
        }
        #endregion

        #region Methodes
        public static bool CheckEntryName(string name)
        {
            //name = "P- Henri";
            //si le nom débute ou termine par un espace ou un tiret
            if (name.StartsWith(" ") || name.StartsWith("-") || name.EndsWith(" ") || name.EndsWith("-"))
            {
                //MessageBox.Show($"La saisie {name} ne peut commencer ou se terminer par un espace ou un tiret", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //si le nom contient au moins un double espace.
            if (name.Contains(" ") || name.Contains("--"))
            {
                //MessageBox.Show($"La saisie {name} comporte au moins un double espace ou tiret non autorisé", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //test s'il y a présence de caractère spéciaux (en dehors de l'alphabet) ou accentués sans tenir compte d'un espace ou un tiret (derrière le Z: Z -)
            if (!Regex.IsMatch(name, @"^[a-zA-Z -]*$"))
            {
                //MessageBox.Show($"La saisie {name} ne peut comporter de caractères spéciaux ou accentués", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            string[] nameParts = name.Split('-', ' ');
            foreach (string s in nameParts)
            {
                //test si la première lettre est une majuscule et les suivantes de a à z en minuscule et sans accent
                if (!Regex.IsMatch(s, @"^[A-Z][a-z]*$"))
                {
                    //MessageBox.Show($"La saisie {name} ne correpond pas aux critères. La première lettre de chaque élément qui compose la saisie doit être une majuscule et les suivantes des minuscules.", $"Erreur de saisie {name}", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            //tous les tests concluants, saisie valide.
            return true;
        }

        public static bool CheckEMail(string tryEmail)
        {
            /*format accepté semblable à "a@b.com";
            obligatoirement de 1 à 25 caractères de a z, 0 à 9 puis obligatoirement le @ puis
            obligatoirement de 1 à 20 caractère de a z, 0 à 9 puis un . puis 2 à 3 caractères (be, com, fr, ...*/
            if (!string.IsNullOrEmpty(tryEmail))
            {
                if (!Regex.IsMatch(tryEmail, @"^[a-z0-9]{1,25}@[a-z0-9]{1,20}\.[a-z]{2,3}$"))
                {
                    //MessageBox.Show($"L'adresse mail est incorrecte", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }

        private static bool CheckMobilePhoneNumber(string tryPhone)
        {
            if (!string.IsNullOrEmpty(tryPhone))
            {
                // Vérification pour les numéros belges
                if (Regex.IsMatch(tryPhone, @"^(?:\+32|0)4\d{8}$"))
                {
                    return true;
                }
                // Vérification pour les numéros français
                if (Regex.IsMatch(tryPhone, @"^(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}$"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        //Check birthday
        private static bool CheckCorrectBirthday(DateOnly TryBirthday)
        {
            if (TryBirthday == default)
            {
                return false;
            }
            else if (TryBirthday > DateOnly.FromDateTime(DateTime.Today))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Check Gender 
        private static bool CheckGender(String CheckGender)
        {

            if (!string.IsNullOrEmpty(CheckGender))
            {
                string lowercaseGender = CheckGender.ToLower();

                //Si le genre est masuculin
                if (lowercaseGender == "masculin" || lowercaseGender == "m" || lowercaseGender == "homme" || lowercaseGender == "male")
                {
                    return true;
                }
                //Si le genre est féminin
                else if (lowercaseGender == "féminin" || lowercaseGender == "f" || lowercaseGender == "femme" || lowercaseGender == "female")
                {
                    return true;
                }

                // Si le genre est autre
                else if (lowercaseGender == "autre" || lowercaseGender == "neutre" || lowercaseGender == "non binaire")
                {
                    return true;
                }
            }
            // Si le genre n'est ni masculin, ni féminin, ni autre
            return false;
        }

        //check password
        public static bool CheckPassword(string password, string firstName, string lastName)
        {


            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                if (password.ToLower().Contains(firstName.ToLower()) ||
                    password.ToLower().Contains(lastName.ToLower()))
                {
                    //MessageBox.Show("Le mot de passe ne peut comporter ni votre nom ni votre prénom",
                    //              "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            if (password.Length < MIN_CHAR_PASSWORD)
            {
                //MessageBox.Show("Le mot de passe doit comporter au moins " + MIN_CHAR_PASSWORD + " caractères", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            if (password.Length > MAX_CHAR_PASSWORD)
            {
                //MessageBox.Show("Le mot de passe doit comporter maximum " + MAX_CHAR_PASSWORD + " caractères", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }

            //test s'il y a présence de caractères spéciaux (en dehors de l'alphabet) ou accentués 
            //test si chaque caractère du début à la fin est dans l'intervalle a-z ou A-Z ascii
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]*$"))
            {
                //MessageBox.Show($"Le mot de passe ne peut comporter que des lettres de l'alphabet non accentuées", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            //test s'il y a présence d'au moins un chiffre nimporte où dans le mot
            //dans ce cas il faut enlevent ^ * sinon cela voudrait dire est ce que tous les caractères du début à la fin sont des chiffres.
            if (!Regex.IsMatch(password, @"[0-9]+"))
            {
                //MessageBox.Show($"Le mot de passe doit comporter au moins un chiffre.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (!Regex.IsMatch(password, @"[A-Z]+"))  //if (!Regex.IsMatch(password, @"^(?=.*[A-Z]).+$"))
            {
                //MessageBox.Show($"Le mot de passe doit comporter au moins une majuscule.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        public bool IsRightPassword(string tryPassword)
        {
            return tryPassword.Equals(this.Password);
        }
        public bool ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {

            if (IsRightPassword(oldPassword))//match old password input and actual Password
            {
                if (newPassword.Equals(confirmNewPassword))
                {
                    Password = newPassword; //attempt to modify property
                    return newPassword.Equals(Password); //if attempt is successful, Password and newPassword are equals.
                }
                else
                {
                    //MessageBox.Show($"Le nouveau mot de passe et sa confirmation ne correspondent pas",
                    // "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show($"L'ancien mot de passe ne correspond pas.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        public string SendHashPassword()
        {
            string hashPassword = string.Empty;

            if (string.IsNullOrEmpty(Password))
            {
                Password = DEFAULT_PASSWD;
            }
            char[] charArrayPassword = Password.ToCharArray();
            for (int i = charArrayPassword.Length - 1; i >= 0; i--)
            {
                hashPassword += (char)((int)(charArrayPassword[i]) + KEY_HASH_PASSWORD);
            }

            return hashPassword;

        }
        public static string GetHashPassword(string hashPassword)
        {

            string password = string.Empty;
            char[] charArrayHashPassword = hashPassword.ToCharArray();
            for (int i = charArrayHashPassword.Length - 1; i >= 0; i--)
            {
                password += (char)((int)(charArrayHashPassword[i]) - KEY_HASH_PASSWORD);
            }
            return password;
        }

        public bool RequestAppointment(DateTime appointmentTime)
        {
            if (this is Client client) // Vérifie si l'utilisateur est déjà un client
            {
                // Si l'utilisateur est déjà un client, il peut prendre un rendez-vous directement
                client.TakeAppointment(appointmentTime);
                return true;
            }
            else
            {
                // Si l'utilisateur n'est pas déjà un client
                var address = new Address(0, "", 0, "", Address.whichCountry.Belgium);
                var clientUser = new Client(this.Id, this.LastName, this.FirstName, this.Email, this.Birthday, this.PhoneNumber, this.Gender, this.Password, address);
                clientUser.TakeAppointment(appointmentTime);
                return true;
            }
            #endregion
        }
    }
}
