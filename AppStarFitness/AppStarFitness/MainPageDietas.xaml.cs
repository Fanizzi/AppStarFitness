﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppStarFitness.View;

namespace AppStarFitness
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDietas : TabbedPage
    {
        public MainPageDietas()
        {
            InitializeComponent();
        }

        private void pck_dieta_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try
            {
    
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }*/
        }

        private async void btn_dieta_Clicked(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }
    }
}