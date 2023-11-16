﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercicioDetalhado : ContentPage
	{
        int tempo_de_descanso = 10;

        bool condicao = true;

        public ExercicioDetalhado()
		{
			InitializeComponent();

            lbl_timer_descanso.Text = tempo_de_descanso.ToString();
        }

        private void btn_timer_Clicked(object sender, EventArgs e)
        {
            condicao = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if(tempo_de_descanso == 0)
                {
                    Parar();
                    tempo_de_descanso = 11;
                }

                if (condicao == true)
                {
                    tempo_de_descanso -= 1;

                    lbl_timer_descanso.Text = tempo_de_descanso.ToString();

                    return true;
                }
                else
                {
                    return false;
                }
            });

            btn_timer.IsEnabled = false;
        }

        void Parar()
        {
            condicao = false;
            btn_timer.IsEnabled = true;
        }

        private void btn_parar_Clicked(object sender, EventArgs e)
        {
            Parar();
        }
    }
}