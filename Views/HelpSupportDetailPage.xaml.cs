
using ShopApp.DataAcces;
using ShopApp2;
using System.Collections.ObjectModel;

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
        if (query.TryGetValue("id", out var id))
        {
            Title = $"Cliente: {id}";
        }
    }
}

public class HelpSupportDetailData : BindingUtilObject
{
    public HelpSupportDetailData()
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
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
