using System.Net;

namespace SCoelloS6.Views;

public partial class Vagregar : ContentPage
{
	public Vagregar()
	{
		InitializeComponent();
	}

    private void BtnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", Txtnombre.Text);
            parametros.Add("apellido", Txtapellido.Text);
            parametros.Add("edad", TxtEdad.Text);
			cliente.UploadValues("http://192.168.100.9/moviles/wsestudiantes.php", "POST", parametros);
			Navigation.PushAsync(new VEstudiantes1());
        }
		catch (Exception ex)
		{

			DisplayAlert("Alerta", ex.Message, "cerrar");
		}
    }
}