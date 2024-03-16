using GestionDeReservation.Model.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.Service
{
    public class Workshop : Service
    {
        private List<DateTime> _dateOfWorkshop;
        private List<User> _participentList;

        public Workshop(string name, double price, ServiceDuration serviceDuration, List<DateTime> dateOfWorkshop, List<User> participentList) : base(name, price, serviceDuration)
        {

        }
    }
}
