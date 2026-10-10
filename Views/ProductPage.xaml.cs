using ShopApp.DataAcces;

namespace ShopApp.Views
{
    public partial class ProductsPage : ContentPage
    {
        List<Product> productos = new();

        public ProductsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarProductos();
        }

        private void CargarProductos()
        {
            using var dbcontext = new ShopDbContext();

            productos = dbcontext.Products.ToList();

            MostrarProductos(productos);
        }

        private void MostrarProductos(List<Product> lista)
        {
            container.Children.Clear();

            foreach (var p in lista)
            {
                var frame = new Border
                {
                    BackgroundColor = Color.FromArgb("#512BD4"),
                    StrokeThickness = 0,
                    Padding = new Thickness(15, 10),
                    Margin = new Thickness(0, 2),
                    Content = new Label
                    {
                        Text = p.Nombre,
                        FontSize = 16,
                        TextColor = Colors.White,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                };

                var tap = new TapGestureRecognizer();

                tap.Tapped += async (sender, e) =>
                {
                    await Navigation.PushAsync(new ProductDetailPage(p));
                };

                frame.GestureRecognizers.Add(tap);

                container.Children.Add(frame);
            }
        }

        private void BuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = e.NewTextValue ?? "";

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarProductos(productos);
                return;
            }

            var resultados = productos
                .Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();

            MostrarProductos(resultados);
        }
    }
}