using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data;

namespace Pokedex.Modelo {
    internal class EscolherPokemon {

        public static async Task SelecionarPokemon(string nome) {
            try {
                using (HttpClient client = new HttpClient()) {
                    string resposta = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nome}");
                    Console.WriteLine(resposta);
                }
            } catch(Exception ex) {
                Console.WriteLine($"Pokemon não encontrado {nome},tente colocar a primeira letra");
                Console.WriteLine($"erro: {ex.Message}");
                Console.WriteLine("Vamos tentar denovo");
                Thread.Sleep(5000);
                Console.Clear();
                await Menu.ExibirMenu();
            }

        }
    }
}
