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
            // CONFIG_FILE POUR TOUR ↓↓↓
            //string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Config.txt";
            // CONFIG_FILE POUR PORTABLE ↓↓↓

            string CONFIG_FILE = @"C:\POO\MAUI\GestionDeReservation\GestionDeReservation\Configuration\Datas\Csv\";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dataFilesManager);


            UserMembersCollection userMembers = daCsv.GetAllUserMembers();
            userMembers.ToList().ForEach(um => lblDebug.Text += $"\n UserMember: {um.Id} / {um.FirstName}/ {um.LastName}/ {um.Gender}/ {um.Email}");
        }
    }

}
