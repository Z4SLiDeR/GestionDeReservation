using GestionDeReservation.Utilities.DataAccess.Files;
using GestionDeReservation.Utilities.Interfaces;
using GestionDeReservation.Model.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GestionDeReservation.Utilities.DataAccess
{
    public class DataAccessCsvFile : DataAccess , IDataAccess
    {

        public DataAccessCsvFile(string filePath) : base(filePath)
        {
        }
        public DataAccessCsvFile(DataFilesManager dfm) : base(dfm) { }

        public override UserMembersCollection GetAllUserMembers()
        {
            List<string> listToRead = new List<string>();
            UserMembersCollection userMembers = new UserMembersCollection();
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PEOPLE");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    User u = GetUserMember(s);
                    if (u != null)
                    {
                        userMembers.AddUserMember(u);
                    }
                }
                return userMembers;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }//end GetAllItems

        /// <summary>
        /// Split a line like : Customer;1;Beumier;Damien;true;beumierdamien@gmail.com;485678234;New;;;;
        /// and create instance with each fields.
        /// </summary>
        /// <param name="csvline"></param>
        /// <returns></returns>
        private static User GetUserMember(string csvline)
        {
            Address address = null; // à changer 
            string[] fields = csvline.Split(';');
            switch (fields[0])
            {
                case "USER":
                    return new User(id: int.Parse(fields[1]), lastName: fields[2], firstName: fields[3], email: fields[4], birthday: DateOnly.Parse(fields[5]), phoneNumber: fields[6], gender: fields[7], password: fields[8], address: address);

                case "CLIENT":
                    return new Client(id: int.Parse(fields[1]), lastName: fields[2], firstName: fields[3], email: fields[4], birthday: DateOnly.Parse(fields[5]), phoneNumber: fields[6], gender: fields[7], password: fields[8], address: address);

                case "ADMIN":
                    return new Admin(id: int.Parse(fields[1]), lastName: fields[2], firstName: fields[3], email: fields[4], birthday: DateOnly.Parse(fields[5]), phoneNumber: fields[6], gender: fields[7], password: fields[8], role: Admin.AdminType.Direction ,address: address);

                default:
                    return null;
            }

        }

    }//end class DataAccessCsvFile
}
