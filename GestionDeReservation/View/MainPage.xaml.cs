using GestionDeReservation.Utilities.DataAccess;
using GestionDeReservation.Utilities.DataAccess.Files;
using GestionDeReservation.Model.People;

namespace GestionDeReservation
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            lblDebug = new Label();
        }

        private void ButtonTestInterfaceAndDataAccess_Clicked(object sender, EventArgs e)
        {

            string CONFIG_FILE = @"C:\POO\MAUI\GestionDeReservation\GestionDeReservation\Configuration\Datas\Config.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dataFilesManager);


            UserMembersCollection userMembers = daCsv.GetAllUserMembers();
            userMembers.ToList().ForEach(um => lblDebug.Text += $"\n UserMember: {um.Id} / {um.FirstName}/ {um.LastName}/ {um.Gender}/ {um.Email}");
        }
    }

}
