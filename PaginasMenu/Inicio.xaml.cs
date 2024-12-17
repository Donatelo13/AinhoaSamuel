namespace ProyectoFinal.PaginasMenu;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

    // Evento que se ejecuta cuando el usuario hace clic en el bot�n "Cerrar Sesi�n"
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        // Cambiar la MainPage a la p�gina de inicio de sesi�n (LoginPage)
        Application.Current.MainPage = new MainPage();
    }
}