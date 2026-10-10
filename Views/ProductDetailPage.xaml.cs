using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage(Product producto)
    {
        InitializeComponent();

        nombreLabel.Text = producto.Nombre;
        descriptionLabel.Text = producto.Description;
        precioLabel.Text = producto.Precio.ToString();

        if (producto.Nombre == "Radio Digital")
            productoImage.Source = "radio_digital.png";
        else if (producto.Nombre == "Reloj electrónico")
            productoImage.Source = "reloj_electronico.png";
        else if (producto.Nombre == "Laptop HP")
            productoImage.Source = "laptop_hp.png";
        else if (producto.Nombre == "Laptop Acer")
            productoImage.Source = "laptop_acer.png";
        else if (producto.Nombre == "Macbook Apple")
            productoImage.Source = "macbook_apple.png";
        else if (producto.Nombre == "Samsung Galaxy")
            productoImage.Source = "samsung_galaxy.png";
        else if (producto.Nombre == "Iphone 14")
            productoImage.Source = "iphone_14.png";
    }
}