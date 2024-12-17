namespace ProyectoFinal.PaginasMenu;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

    // Evento que se ejecuta cuando el usuario hace clic en el botón "Cerrar Sesión"
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        // Cambiar la MainPage a la página de inicio de sesión (LoginPage)
        Application.Current.MainPage = new MainPage();
    }
}