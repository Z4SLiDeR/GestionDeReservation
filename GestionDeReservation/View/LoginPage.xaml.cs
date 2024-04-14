namespace GestionDeReservation.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (pseudo.Text == "jeremy" && pass.Text == "1234")
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Erreur", "Pseudo ou mot de passe incorrect", "OK");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await DisplayAlert("Erreur", "Pas encore implémenté", "OK");
    }
}