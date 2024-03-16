using GestionDeReservation.Model.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.Service
{
    public class Formation
    {
        private string _name;
        List<DateTime> _formationDateList;
        List<User> _participantList;
        private double _pricePerUser;
        private DateTime _startOfFormation;
        private DateTime _endOfFormation;

        public Formation() { } 
    }
}
