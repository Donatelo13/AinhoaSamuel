namespace ProyectoFinal
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = userEntry.Text;
            string password = passwordEntry.Text;

            // Validación simple de credenciales
            if (username == "admin" && password == "1234")
            {
                // Cambiar la MainPage a AppShell, utilizando NavigationPage
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                errorLabel.Text = "Usuario o contraseña incorrectos";
                errorLabel.IsVisible = true;
            }
        }
    }
}
