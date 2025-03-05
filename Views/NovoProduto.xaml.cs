using MauiAppMinhasCompras.Models;
using System;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class NovoProduto : ContentPage
    {
        public NovoProduto()
        {
            InitializeComponent();
        }

        async void OnSalvarProduto(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                return;
            }

            var produto = new Produto
            {
                Descricao = txtDescricao.Text,
                Quantidade = Convert.ToDouble(txtQuantidade.Text),
                Preco = Convert.ToDouble(txtPreco.Text)
            };

            await App.Db.Insert(produto);
            await DisplayAlert("Sucesso", "Produto adicionado!", "OK");
            await Navigation.PopAsync();
        }
    }
}