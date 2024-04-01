using GestionDeReservation.Model.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GestionDeReservation.Model.Service;

namespace GestionDeReservation.Model.Appointement
{
    public class Appointement
    {
        private string _lastName;
        private string _firstName;
        private DateTime _appointementRequest;
        //private Service _requestType;
        private ConfirmationStep _confirmationStep; 
        public enum ConfirmationStep
        {
            WaitingConfirmation,
            Accepted,
            Canceled,
            finished
        }

        #region GetAndSet
        #endregion
        #region Methodes
        #endregion
    }
}
