using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.Service
{
    public abstract class Service
    {
        private string _name;
        private double _price;
        private ServiceDuration _serviceDuration;
        public enum ServiceDuration
        {
            ThirtyMinutes = 30,
            OneHour = 60,
            TwoHours = 120,
            TwoAndHalfHours = 150,
            ThreeHours = 180
        }
        public Service(string name, double price, ServiceDuration serviceDuration) 
        {
            _name = name;
            _price = price;
            _serviceDuration = serviceDuration;
        }
    }
}
