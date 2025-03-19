using MauiAppMinhasCompras.Models;
using System;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class EditarProduto : ContentPage
    {
        Produto _produto;

        public EditarProduto(Produto produto)
        {
            InitializeComponent();
            _produto = produto;
            PreencherCampos();
        }

        void PreencherCampos()
        {
            txtDescricao.Text = _produto.Descricao;
            txtQuantidade.Text = _produto.Quantidade.ToString();
            txtPreco.Text = _produto.Preco.ToString();
        }

        async void OnSalvarAlteracoes(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                    string.IsNullOrWhiteSpace(txtPreco.Text))
                {
                    await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                    return;
                }

                _produto.Descricao = txtDescricao.Text;
                _produto.Quantidade = Convert.ToDouble(txtQuantidade.Text);
                _produto.Preco = Convert.ToDouble(txtPreco.Text);

                await App.Db.Update(_produto);
                await DisplayAlert("Sucesso", "Produto atualizado!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Falha ao atualizar: {ex.Message}", "OK");
            }
        }

        async void OnExcluirProduto(object sender, EventArgs e)
        {
            try
            {
                bool confirmacao = await DisplayAlert("Confirmação", "Deseja excluir este produto?", "Sim", "Não");
                if (confirmacao)
                {
                    await App.Db.Delete(_produto.Id);
                    await DisplayAlert("Sucesso", "Produto excluído!", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Falha ao excluir: {ex.Message}", "OK");
            }
        }
    }
}