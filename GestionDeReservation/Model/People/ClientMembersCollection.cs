using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.People
{
    public class ClientMembersCollection : ObservableCollection<Client>
    {
        public ClientMembersCollection() { }
        public void AddClientMember(Client c)
        {
            if (this.Count == 0 || !this.Any(ClientMemberInTheCollection => ClientMemberInTheCollection.Id == c.Id || (ClientMemberInTheCollection.LastName == c.LastName && ClientMemberInTheCollection.FirstName == c.FirstName)))
            {
                this.Add(c);
            }
            else
            {
                //id ClientMember or ClientMember LastName & FirstName already in the collection and will not be added.
            }

        }
    }
}
