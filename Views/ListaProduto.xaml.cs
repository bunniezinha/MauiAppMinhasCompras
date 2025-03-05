using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        public ListaProduto()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadProdutos();
        }

        async Task LoadProdutos()
        {
            lstProdutos.ItemsSource = await App.Db.GetAll();
        }

        async void OnNovoProduto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoProduto());
        }

        async void OnProdutoTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Produto produto)
            {
                await Navigation.PushAsync(new EditarProduto(produto));
            }
        }
    }
}