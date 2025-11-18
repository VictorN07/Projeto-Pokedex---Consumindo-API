using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data;
using Pokedex.Exceptions;
using System.Text.Json;

namespace Pokedex.Modelo {
    internal class EscolherPokemon {

        public static async Task SelecionarPokemon(string nome) {
            try {
                using (HttpClient client = new HttpClient()) {
                    string resposta = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nome}");
                    Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(resposta)!;
                    if (pokemon?.StatusPokemon != null) {
                        Console.WriteLine($"Nome: {pokemon.Species?.Nome}");
                        foreach (var stats in pokemon.StatusPokemon!) {
                            string? nomeEstatistica = stats.Stat?.Name;
                            int valorBase = stats.StatusBase;
                            if (!string.IsNullOrEmpty(nomeEstatistica)) {
                                Console.WriteLine($"- {nomeEstatistica}: {valorBase}");
                            }
                        }
                    }
                    Console.Write("Aperte Qualquer tecla para continuar:");
                    Console.ReadLine();
                    Console.Clear();
                }
            } catch(Exception) {
                Console.Clear();
                Console.WriteLine($"Pokemon não encontrado {nome}, tente colocar a primeira letra maiuscula");
                await Task.Delay(2500);
                throw new ExceptionPokemonNaoEncontrado();
            }

        }
    }
}
