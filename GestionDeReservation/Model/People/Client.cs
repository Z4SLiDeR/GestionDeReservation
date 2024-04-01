namespace GestionDeReservation.Model.People
{
    public class Client : User
    {
        private int _appointmentsNumber;
        private int _cancellationsNumber;
        public List<bool> ReminderAppointmentMessagesSent { get; set; }
        public List<bool> ConfirmedEmailSent { get; set; }

        public Client(int id, string lastName, string firstName, string email, DateOnly birthday, string phoneNumber, string gender, string password, Address address)
            : base(id,lastName, firstName, email, birthday, phoneNumber, gender, password, address)
        {
            _appointmentsNumber = 0;
            _cancellationsNumber = 0;
            ReminderAppointmentMessagesSent = new List<bool>();
            ConfirmedEmailSent = new List<bool>();
        }

        public int AppointmentsNumber
        {
            get { return _appointmentsNumber; }
            set { _appointmentsNumber = value; }
        }

        public int CancellationsNumber
        {
            get { return _cancellationsNumber; }
            set { _cancellationsNumber = value; }
        }

        // Méthode pour prendre un rendez-vous
        public void TakeAppointment(DateTime appointmentTime)
        {
            _appointmentsNumber++;
            ReminderAppointmentMessagesSent.Add(false);
        }


        // Méthode pour annuler un rendez-vous
        public void CancelAppointment(DateTime cancellationTime, DateTime appointmentTime)
        {
            TimeSpan timeDifference = appointmentTime - cancellationTime;
            if (timeDifference.TotalHours >= 48)
            {
                _cancellationsNumber++;
            }
            else
            {
                _cancellationsNumber++;
                // Génération et envoi de la facture
            }
        }
        private void SendConfirmationEmail()
        {
            // Implémenter la logique d'envoi de l'e-mail de confirmation
            ConfirmedEmailSent[_appointmentsNumber - 1] = true; // Mettez à jour l'indicateur pour le dernier rendez-vous pris
        }

        // Méthode pour envoyer automatiquement les messages de rappel 72 heures avant chaque rendez-vous
        public void SendReminderMessages(List<DateTime> appointmentTimes)
        {
            for (int i = 0; i < appointmentTimes.Count; i++)
            {
                TimeSpan timeDifference = appointmentTimes[i] - DateTime.Now;
                if (timeDifference.TotalHours <= 72 && timeDifference.TotalHours > 0 && !ReminderAppointmentMessagesSent[i])
                {
                    // Envoyer le message de rappel
                    ReminderAppointmentMessagesSent[i] = true;
                }
            }
        }
    }
}
