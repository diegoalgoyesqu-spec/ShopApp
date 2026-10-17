
using ShopApp.DataAcces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
    public HelpSupportPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var dataObject = Resources["data"] as HelpSupportData;

        if (dataObject != null)
        {
            dataObject.VisitasPendientes = 30;
        }
    }
}

public class HelpSupportData : INotifyPropertyChanged
{
    private int _visitasPendientes = 5;
    private ObservableCollection<Client> _clients = new();
    private Client _clienteSeleccionado;

    public HelpSupportData()
    {
        var database = new ShopDbContext();
        Clients = new ObservableCollection<Client>(database.Clients);
        PropertyChanged += HelpSupportData_PropertyChanged;
    }

    private async void HelpSupportData_PropertyChanged(
        object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ClienteSeleccionado)
            && ClienteSeleccionado != null)
        {
            var uri = $"{nameof(HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";
            await Shell.Current.GoToAsync(uri);
        }
    }

    public int VisitasPendientes
    {
        get { return _visitasPendientes; }
        set
        {
            if (_visitasPendientes != value)
            {
                _visitasPendientes = value;
                RaisePropertyChanged();
            }
        }
    }

    public ObservableCollection<Client> Clients
    {
        get { return _clients; }
        set
        {
            if (_clients != value)
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }
    }

    public Client ClienteSeleccionado
    {
        get { return _clienteSeleccionado; }
        set
        {
            if (_clienteSeleccionado != value)
            {
                _clienteSeleccionado = value;
                RaisePropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChanged(
        [CallerMemberName] string nombre = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(nombre));
    }
}

