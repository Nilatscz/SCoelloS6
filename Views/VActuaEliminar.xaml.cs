//using AVFoundation;
//using Java.Net;
using Newtonsoft.Json;
using SCoelloS6.Models;
using System.Net;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SCoelloS6.Views;

public partial class VActuaEliminar : ContentPage
{
    private const string url = "http://192.168.100.9/moviles/wsestudiantes.php";
    private readonly HttpClient cliente = new HttpClient();
    private Estudiantes estudiantes;

    public VActuaEliminar(Estudiantes datos)
	{
		InitializeComponent();
        txtCodigo.Text=datos.codigo.ToString();
        txtnombre.Text = datos.nombre;
        txtapellido.Text = datos.apellido;
        txtedad.Text = datos.edad.ToString();
       
        
        }

    private async void BtnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var parametros = new Dictionary<string, string>
    {
        { "codigo", txtCodigo.Text },
        { "nombre", txtnombre.Text },
        { "apellido", txtapellido.Text },
        { "edad", txtedad.Text }
    };
            var content = new FormUrlEncodedContent(parametros);
            var response = await cliente.PutAsync
                ($"{url}?codigo={txtCodigo.Text}&nombre={txtnombre.Text}&apellido={txtapellido.Text}&edad={txtedad.Text}",
                content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Estudiante actualizado correctamente", "OK");
                await Navigation.PushAsync(new VEstudiantes1());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el estudiante", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Cerrar");
        }


    }

    private async void BtnEliminar_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirmar", "¿Estás seguro de eliminar este estudiante?", "Sí", "No");
        if (answer)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                cliente.UploadValues($"{url}?codigo=" + txtCodigo.Text, "DELETE", parametros);
                await DisplayAlert("Éxito", "Estudiante eliminado correctamente", "Cerrar");
                await Navigation.PushAsync(new VEstudiantes1());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

    }
}