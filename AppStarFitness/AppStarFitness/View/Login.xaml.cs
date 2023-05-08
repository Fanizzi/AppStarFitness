﻿using AppStarFitness.DataService;
using AppStarFitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            logo.Source = ImageSource.FromResource("AppStarFitness.View.logo.png");
        }

        private async void btn_entrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string[] cpf_pontuado = usuario.Text.Split('.', '-');
                string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];
                string senha_digitada = senha.Text;

                Aluno a = await DataServiceAluno.AutenticarAluno(new Aluno
                {
                    cpf = cpf_digitado,
                    senha = senha_digitada
                });
            } catch (Exception err)
            {
                await DisplayAlert("Ops", err.Message, "OK");
            }

            // CPF CADASTRADO NO BANCO
            /*string cpf_cadastrado = "12345678910";
            string senha_cadastrada = "teste";

            if (cpf_digitado == cpf_cadastrado && senha_digitada == senha_cadastrada)
            {
                App.Current.Properties.Add("usuario_logado", cpf_digitado);
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                DisplayAlert("Erro", "Dados incorretos!", "OK");
            }*/
        }

        private void btn_esqueci_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new View.EsqueciSenha());
        }
    }
}