using GestionDeReservation.Model.People;
using GestionDeReservation.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.Appointement
{
    public class Appointement
    {
        private Client _client;
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
