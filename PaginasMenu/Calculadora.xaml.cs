namespace ProyectoFinal.PaginasMenu;

public partial class Calculadora : ContentPage
{
    public Calculadora()
    {
        InitializeComponent();
    }

    // Evento para manejar el cambio en la unidad de peso
    private void UnidadPesoPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (unidadPesoPicker.SelectedItem != null)
        {
            string unidadSeleccionada = unidadPesoPicker.SelectedItem.ToString();
            if (unidadSeleccionada == "Libras")
            {
                DisplayAlert("Cambio de Unidad", "Has seleccionado Libras. Asegúrate de ingresar el peso correctamente.", "OK");
            }
            else
            {
                DisplayAlert("Cambio de Unidad", "Has seleccionado Kilogramos. Asegúrate de ingresar el peso correctamente.", "OK");
            }
        }
    }

    // Evento para manejar el cambio en la unidad de dosis
    private void UnidadDosisPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (unidadDosisPicker.SelectedItem != null)
        {
            string unidadSeleccionada = unidadDosisPicker.SelectedItem.ToString();
            if (unidadSeleccionada == "Miligramos")
            {
                DisplayAlert("Cambio de Unidad", "Has seleccionado Miligramos para la dosis.", "OK");
            }
            else
            {
                DisplayAlert("Cambio de Unidad", "Has seleccionado Gramos para la dosis.", "OK");
            }
        }
    }

    // Evento para manejar el cambio en la unidad de dosis a administrar
    private void UnidadDosisAdministrarPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (unidadDosisAdministrarPicker.SelectedItem != null)
        {
            string unidadSeleccionada = unidadDosisAdministrarPicker.SelectedItem.ToString();
            if (unidadSeleccionada == "Miligramos")
            {
                DisplayAlert("Cambio de Unidad", "Has seleccionado Miligramos para la dosis a administrar.", "OK");
            }
            else
            {
                DisplayAlert("Cambio de Unidad", "Has seleccionado Gramos para la dosis a administrar.", "OK");
            }
        }
    }

    // Evento para manejar el cambio en la frecuencia
    private void FrecuenciaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (frecuenciaPicker.SelectedItem != null)
        {
            string frecuenciaSeleccionada = frecuenciaPicker.SelectedItem.ToString();
            DisplayAlert("Cambio de Frecuencia", $"Has seleccionado: {frecuenciaSeleccionada}.", "OK");
        }
    }

    private void OnCalculateDosisClicked(object sender, EventArgs e)
    {
        // Leer los valores de entrada
        if (double.TryParse(pesoEntry.Text, out double peso) &&
            double.TryParse(dosisPorKgEntry.Text, out double dosisPorKg) &&
            double.TryParse(dosisAdministrarEntry.Text, out double dosisAdministrar))
        {
            // Convertir peso a kg si es necesario
            if (unidadPesoPicker.SelectedItem != null && unidadPesoPicker.SelectedItem.ToString() == "Libras")
            {
                // Convertir libras a kilogramos
                peso /= 2.20462; // 1 libra = 0.453592 kg
            }

            // Calcular dosis
            double dosis = dosisPorKg * peso;

            // Calcular frecuencia
            int frecuencia = 1;
            if (frecuenciaPicker.SelectedItem != null)
            {
                switch (frecuenciaPicker.SelectedItem.ToString())
                {
                    case "Dos veces al día":
                        frecuencia = 2;
                        break;
                    case "Tres veces al día":
                        frecuencia = 3;
                        break;
                    case "Cuatro veces al día":
                        frecuencia = 4;
                        break;
                    case "Cada 4 horas":
                        frecuencia = 6; // 24/4 = 6
                        break;
                    case "Cada 3 horas":
                        frecuencia = 8; // 24/3 = 8
                        break;
                    case "Cada 2 horas":
                        frecuencia = 12; // 24/2 = 12
                        break;
                    case "Cada hora":
                        frecuencia = 24; // 24/1 = 24
                        break;
                }
            }

            // Calcular dosis diaria
            double dosisDiaria = dosis * frecuencia;

            // Mostrar resultados
            resultadoDosisLabel.Text = $"La dosis es: {dosis:F2} mg";
            resultadoDosisDiariaLabel.Text = $"La dosis diaria es: {dosisDiaria:F2} mg";

            // Si el usuario ingresó una dosis a administrar, convertirla a mg si es necesario
            if (unidadDosisAdministrarPicker.SelectedItem != null)
            {
                double dosisAdministrarMg = dosisAdministrar;
                if (unidadDosisAdministrarPicker.SelectedItem.ToString() == "Gramos")
                {
                    dosisAdministrarMg *= 1000; // 1 gramo = 1000 mg
                }

                // Mostrar la dosis a administrar en mg
                resultadoDosisLabel.Text += $"\nDosis a administrar: {dosisAdministrarMg:F2} mg";
            }
        }
        else
        {
            resultadoDosisLabel.Text = "Por favor, ingrese valores válidos.";
            resultadoDosisDiariaLabel.Text = string.Empty;
        }
    }
}