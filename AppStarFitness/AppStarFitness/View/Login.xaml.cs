﻿using AppStarFitness.DataService;
using AppStarFitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            logo.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
        }

        private async void btn_entrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string[] cpf_pontuado = usuario.Text.Split('.', '-');
                string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];
                string senha_digitada = senha.Text;


                string senha_sha1;
                using (var sha1 = new SHA1Managed())
                {
                    senha_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(senha_digitada)));
                    senha_sha1 = string.Join("", senha_sha1.ToLower().Split('-'));
                }

                Aluno a = await DataServiceAluno.AutenticarAluno(new Aluno
                {
                    cpf = cpf_digitado,
                    senha = senha_sha1
                });

                if (a != null)
                {
                    App.Current.Properties.Add("usuario_logado", cpf_digitado);
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    DisplayAlert("Erro", "Dados incorretos!", "OK");
                }

            } catch (Exception err)
            {
                await DisplayAlert("Ops", err.Message, "OK");
            }
        }

        private void btn_esqueci_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new View.EsqueciSenha());
        }
    }
}