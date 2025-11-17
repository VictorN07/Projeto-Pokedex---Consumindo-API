using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Modelo {
    internal class Menu {

        public static async Task ExibirMenu() {
            bool continuar = true
            while (continuar) {
                Console.WriteLine("Escolha para qual area voce deseja acessar \n");
                Console.WriteLine("1.Procurar Pokemon:");
                Console.Write("Digite a sua escolha: ");
                try {
                    int Escolha = int.Parse(Console.ReadLine()!);
                    switch (Escolha) {
                        case 1:
                            Console.Clear();
                            Console.Write("Digite o nome do Pokemon que deseja procurar: ");
                            await EscolherPokemon.SelecionarPokemon(Console.ReadLine()!);
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Você digitou um numero fora da lista. Vamos tentar denovo");
                            Thread.Sleep(5000);
                            Console.Clear();
                            break;
                    }
                } catch (NullReferenceException) {
                    Console.WriteLine("Você não digitou um número. Vamos tentar denovo");
                    Thread.Sleep(3000);
                    Console.Clear();
                } catch (FormatException) {
                    Console.WriteLine("Voce digitou um caracter invés de um número, Vamos tentar denovo");
                    Thread.Sleep(3000);
                }
            }
        }
           

    }
}
