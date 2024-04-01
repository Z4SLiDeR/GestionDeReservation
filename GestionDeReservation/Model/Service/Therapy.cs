using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.System.Update;

namespace GestionDeReservation.Model.Service
{
    public class Therapy : Service
    {
        private string _lastName;
        private string _firstName;
        private List<Accompanying> accompanyingList;

        public Therapy(string name, double price, ServiceDuration serviceDuration, string lastName, string firstName, List<Accompanying> accompanyings) : base(name, price, serviceDuration)
        {

        }
    }
}
