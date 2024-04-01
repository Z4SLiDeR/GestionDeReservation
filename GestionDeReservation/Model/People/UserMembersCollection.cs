using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeReservation.Model.People
{
    public class UserMembersCollection : ObservableCollection<User>
    {
        public UserMembersCollection() { }

        public void AddUserMember(User u)
        {
            if (this.Count == 0 || !this.Any(UserMemberInTheCollection => UserMemberInTheCollection.Id == u.Id || (UserMemberInTheCollection.LastName == u.LastName && UserMemberInTheCollection.FirstName == u.FirstName)))
            {
                this.Add(u);
            }
            else
            {
                //id StaffMember or StaffMember LastName & FirstName already in the collection and will not be added.
            }

        }
    }
}
