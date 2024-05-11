using Newtonsoft.Json;
using SCoelloS6.Models;
using System.Collections.ObjectModel;

namespace SCoelloS6.Views;

public partial class VEstudiantes1 : ContentPage
{
	private const string url = "http://192.168.1.83/moviles/wsestudiantes.php";
	private readonly HttpClient cliente= new HttpClient();
	private ObservableCollection<Estudiantes> est;
	public VEstudiantes1()
	{
		InitializeComponent();
		ObtenerDatos();

    }
	public async void ObtenerDatos()
	{
		var contebt = await cliente.GetStringAsync(url);
		List<Estudiantes>mostrar=JsonConvert.DeserializeObject<List<Estudiantes>>(contebt);
        est = new ObservableCollection<Estudiantes>(mostrar);
		ListCodigos.ItemsSource = est;
		ListNombres.ItemsSource = est;
        ListApellidos.ItemsSource = est;
        ListEdad.ItemsSource = est;

    }

}