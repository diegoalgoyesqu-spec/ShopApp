
using ShopApp.DataAcces;
using ShopApp2;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage, IQueryAttributable
{
    public HelpSupportDetailPage()
    {
        InitializeComponent();
        BindingContext = new HelpSupportDetailData();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Title = $"Cliente: {query["id"]}";
        var clienteId = int.Parse(query["id"].ToString());
        (BindingContext as HelpSupportDetailData).ClienteId = clienteId;
    }
}

public class HelpSupportDetailData : BindingUtilObject
{
    private ObservableCollection<Product> _products;
    private Product _productoseleccionado;
    private int _cantidad;

    public HelpSupportDetailData()
    {var database = new ShopDbContext();
Products = new ObservableCollection<Product>(database.Products);

AddCommand = new MiComando(() =>
{
    var compra = new Compra(ClienteId, productoseleccionado.Id, cantidad);
    Compras.Add(compra);
},
() => true);
    }
    public ICommand AddCommand { get; set; }

    private ObservableCollection<Compra> _compras = new ObservableCollection<Compra>();
    public ObservableCollection<Compra> Compras
    {
        get { return _compras; }
        set
        {
            if (_compras != value)
            {
                _compras = value;
                RaisePropertyChanged();
            }
        }
    }

    private int _clienteId;

    public int ClienteId
    {
        get { return _clienteId; }
        set { _clienteId = value; }

    }

    public ObservableCollection<Product> Products
    {
        get { return _products; }
        set
        {
            if (_products != value)
            {
                _products = value;
                RaisePropertyChanged();
            }
        }
    }

    public Product productoseleccionado
    {
        get { return _productoseleccionado; }
        set
        {
            if (_productoseleccionado != value)
            {
                _productoseleccionado = value;
                RaisePropertyChanged();
            }
        }
    }

    public int cantidad
    {
        get { return _cantidad; }
        set
        {
            if (_cantidad != value)
            {
                _cantidad = value;
                RaisePropertyChanged();
            }
        }
    }
}
