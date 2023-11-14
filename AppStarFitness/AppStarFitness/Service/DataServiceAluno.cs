﻿using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;

namespace AppStarFitness.DataService
{
    public class DataServiceAluno : DataService
    {
        public static async Task<Mensalidade> MensalidadeAluno(Usuario usuario)
        {
            string token = usuario.token;
            string id_aluno = usuario.user.gymMember.id;

            string json = await DataService.GetDataFromService("/billing/" + id_aluno, token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("MENSALIDADE ALUNO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_Mensalidade root = JsonConvert.DeserializeObject<Root_Mensalidade>(json);

            return root.data;
        }

        public static async Task<EvolucaoAluno> NovaEvolucao(EvolucaoAluno e, Usuario usuario)
        {
            string token = usuario.token;

            var json_a_enviar = JsonConvert.SerializeObject(e);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("NOVA EVOLUCAO - JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/evolution", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("NOVA EVOLUCAO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_Evolucao root =  JsonConvert.DeserializeObject<Root_Evolucao>(json);

            return root.data;
        }

        public static async Task<Medidas> MedidasAluno(Medidas m, Usuario usuario)
        {
            string token = usuario.token;

            var json_a_enviar = JsonConvert.SerializeObject(m);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("MEDIDAS ALUNO - JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/measurement", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("MEDIDAS ALUNO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return JsonConvert.DeserializeObject<Medidas>(json);
        }

        public static async Task<List<EvolucaoAlunoList>> PuxarEvolucoes(Usuario usuario)
        {
            string token = usuario.token;

            string json = await DataService.GetDataFromService("/evolution", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR EVOLUÇÕES - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_EvolucaoList root = JsonConvert.DeserializeObject<Root_EvolucaoList>(json);
            var dados = JsonConvert.SerializeObject(root.data);
            List<EvolucaoAlunoList> evolucoes = JsonConvert.DeserializeObject<List<EvolucaoAlunoList>>(dados);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR EVOLUÇÕES - ARRAY EVOLUCOES");
            foreach (var evolucao in evolucoes)
            {
                Console.WriteLine($"ID: {evolucao.id}");
                Console.WriteLine($"Complete Date: {evolucao.complete_date}");
                Console.WriteLine($"ID Gym Member: {evolucao.id_gym_member}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return evolucoes;
        }
    }
}
