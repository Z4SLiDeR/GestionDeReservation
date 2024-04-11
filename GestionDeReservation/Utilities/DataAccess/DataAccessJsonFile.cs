using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using GestionDeReservation.Utilities.Interfaces;
using GestionDeReservation.Utilities.DataAccess.Files;
using GestionDeReservation.Model.People;

namespace GestionDeReservation.Utilities.DataAccess
{
    public class DataAccessJsonFile : DataAccess, IDataAccess
    {

        public DataAccessJsonFile(string filePath) : base(filePath)
        {
        }
        public DataAccessJsonFile(string filePath, string[] extensions) : base(filePath, extensions)
        {

        }

        public DataAccessJsonFile(DataFilesManager dfm) :base(dfm)
        {
            
        }
        /// <summary>
        /// retrieve all items object in an ItemCollection from json File Code ITEMS.
        /// </summary>
        /// <returns></returns>
        public override UserMembersCollection GetAllUserMembers()
        {

            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PEOPLE");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                UserMembersCollection? its = new UserMembersCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                its = JsonConvert.DeserializeObject<UserMembersCollection>(jsonFile, settings);
                return its;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }//end GetAllItems

        public override UserMembersCollection GetAllClientMembers()
        {

            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PEOPLE");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                UserMembersCollection? its = new UserMembersCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                its = JsonConvert.DeserializeObject<UserMembersCollection>(jsonFile, settings);
                return its;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }

        public void UpdateAllMembersDatas(UserMembersCollection userMembers)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PEOPLE");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(userMembers, Formatting.Indented, settings);

                File.WriteAllText(AccessPath, json);
            }
            else
            {
                Console.WriteLine("UpdateAllCustomersDatas error can't update datasource file");
            }
        }

        public void UpdateAllClientsDatas(UserMembersCollection clientMembers)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PEOPLE");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(clientMembers, Formatting.Indented, settings);

                File.WriteAllText(AccessPath, json);
            }
            else
            {
                Console.WriteLine("UpdateAllCustomersDatas error can't update datasource file");
            }
        }

    }
}
