using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
    List<Client> clientes = new();

    public ClientsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarClientes();
    }

    private void CargarClientes()
    {
        using var dbcontext = new ShopDbContext();

        clientes = dbcontext.Clients.ToList();

        MostrarClientes(clientes);
    }

    private void MostrarClientes(List<Client> lista)
    {
        container.Children.Clear();

        foreach (var cliente in lista)
        {
            var boton = new Button
            {
                Text = cliente.Nombre,
                FontSize = 16,
                TextColor = Colors.White,
                BackgroundColor = Color.FromArgb("#512BD4"),
                CornerRadius = 10,
                Margin = new Thickness(0, 3)
            };

            boton.CommandParameter = cliente;

            boton.Clicked += Cliente_Clicked;

            container.Children.Add(boton);
        }
    }

    private async void Cliente_Clicked(object sender, EventArgs e)
    {
        if (sender is Button boton && boton.CommandParameter is Client cliente)
        {
            await DisplayAlert(
                "Cliente",
                $"Nombre: {cliente.Nombre}\nDirección: {cliente.Direccion}",
                "Aceptar");
        }
    }

    private void BuscarCliente_TextChanged(object sender, TextChangedEventArgs e)
    {
        string texto = e.NewTextValue ?? "";

        var resultados = clientes
            .Where(c => c.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase))
            .ToList();

        MostrarClientes(resultados);
    }
}