using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.People
{
    public class Address
    {
        private int _postalCode;
        private string _streetName;
        private int _houseNumber;
        private string _houseNumberExtension;
        private Country _country;
        public enum Country
        {
            Belgium,
            France
        }

        public Address(int postalCode, string streetName, int houseNumber, string houseNumberExtension, Country country)
        {

        }
        public Address(int postalCode, string streetName, int houseNumber, Country country)
        {

        }

        #region GetAndSet
        #endregion
        #region Methodes
        #endregion
    }
}
