﻿using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace AppStarFitness.DataService
{
    public class DataServicePessoa : DataService
    {
        // Envia dados preenchidos do aluno para autenticar ele pela nossa API | POST
        public static async Task<Pessoa> AutenticarPessoa(Pessoa p)
        {
            var json_a_enviar = JsonConvert.SerializeObject(p);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/login/gym-member");

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            if (json == "false")
                return null;

            // ===============================================================================================

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);


            //dynamic usuario = JsonConvert.DeserializeObject(json);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("TESTE DADOS");
            Console.WriteLine(JsonConvert.SerializeObject(usuario));
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return usuario.user;
        }
    }
}