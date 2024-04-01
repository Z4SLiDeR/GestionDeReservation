using GestionDeReservation.Model.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Utilities.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Access string to the external source (file path, connection string ...)
        /// </summary>
        string AccessPath
        {
            get;
            set;
        }

        UserMembersCollection GetAllUserMembers();

    }
}
