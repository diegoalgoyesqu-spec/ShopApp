using ShopApp.DataAcces;

namespace ShopApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarContadores();
        }

        private void CargarContadores()
        {
            using var dbcontext = new ShopDbContext();

            var totalCategorias = dbcontext.Categories.Count();
            var totalClientes = dbcontext.Clients.Count();
            var totalProductos = dbcontext.Products.Count();

            CategoriasLabel.Text = totalCategorias.ToString();
            ClientesLabel.Text = totalClientes.ToString();
            ProductosLabel.Text = totalProductos.ToString();
        }

        private async void Cliente_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new ClientsPage());
        }

        private async void Producto_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }

        private async void Categoria_Tapped(object sender, TappedEventArgs e)
        {
            await DisplayAlert("Categorías", "Apartado de categorías", "Aceptar");
        }
    }
}