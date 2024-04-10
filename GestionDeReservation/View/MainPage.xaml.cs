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
            userMembers.ToList().ForEach(um => lblDebug.Text += $"\n UserMember: {um.Id} / {um.FirstName}/ {um.LastName}/ {um.Email}");
        }

        private void buttonTestDataAccessJsonFile_Clicked(object sender, EventArgs e)
        {
            string CONFIG_FILE = @"C:\POO\MAUI\GestionDeReservation\GestionDeReservation\Configuration\Datas\Config.txt";

            // Initialisation du gestionnaire de fichiers de données
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);

            // Initialisation de l'accès aux données JSON
            DataAccessJsonFile da = new DataAccessJsonFile(dataFilesManager);

            // Récupération de tous les éléments
            UserMembersCollection members = da.GetAllUserMembers();

            // Affichage des informations de chaque élément
            members.ToList().ForEach(it => lblDebug.Text += $"\n UserMember: {it.Id} / {it.FirstName}/ {it.LastName}/ {it.Email} / {it.Birthday}");

            // Sauvegarde des données mises à jour
            //da.UpdateAllMembersDatas(members);
        }

    }

}
