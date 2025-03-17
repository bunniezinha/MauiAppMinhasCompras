using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        private List<Produto> produtos;

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
            produtos = await App.Db.GetAll();
            lstProdutos.ItemsSource = produtos;
            
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

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = e.NewTextValue?.ToLower() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                lstProdutos.ItemsSource = produtos; // Sem filtro, exibe tudo
            }
            else
            {
                lstProdutos.ItemsSource = produtos
                    .Where(p => p.Descricao.ToLower().Contains(filtro))
                    .ToList();
            }
        }
    }
}