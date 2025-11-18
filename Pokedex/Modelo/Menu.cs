using Pokedex.Exceptions;

namespace Pokedex.Modelo {
    internal class Menu {
        public static async Task ExibirMenu() {
            bool continuar = true;
            while (continuar) { 
                Console.WriteLine("Escolha para qual area voce deseja acessar \n");
                Console.WriteLine("1.Procurar Pokemon:");
                Console.Write("Digite a sua escolha: ");
                try {
                    int Escolha = int.Parse(Console.ReadLine()!);
                    switch (Escolha) {
                        case 1:
                            Console.Clear();
                            bool y = true;
                            while (y) {
                                try {
                                    Console.Write("Digite o nome do Pokemon que deseja procurar: ");
                                    await EscolherPokemon.SelecionarPokemon(Console.ReadLine()!);

                                } catch (ExceptionPokemonNaoEncontrado) {
                                    Console.WriteLine("Vamos tentar denovo");
                                    await Task.Delay(2000);
                                    Console.Clear();
                                }
                                bool tente = true;
                                while (tente) {
                                    Console.Clear();
                                    Console.Write("Deseja Fazer Uma nova Pesquisa?(S/N): ");
                                    string resp = Console.ReadLine()!.ToUpper();
                                    if (resp == "N") {
                                        y = false;
                                        tente = false;
                                    } else if (resp == "S") {
                                        tente = false;
                                    } else {
                                        Console.WriteLine("Por favor digite um valor aceitavel");
                                    }
                                }
                                Console.Clear();
                            }
                            continuar = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Você digitou um numero fora da lista.");
                            bool x = true;
                            while (x) {
                                Console.Write("Deseja Tentar denovo?(S/N): ");
                                try {
                                    string resp = Console.ReadLine()!.ToUpper();
                                    if (resp == "N") {
                                        continuar = false;
                                    }
                                    x = false;
                                    Console.Clear();
                                } catch (NullReferenceException) {
                                    Console.WriteLine("Sua resposta é nula, vamos tentar denovo");
                                    await Task.Delay(2000);
                                    Console.Clear();
                                }
                            }
                            break;
                    }
                } catch (NullReferenceException) {
                    Console.WriteLine("Você não digitou um número. Vamos tentar denovo");
                    await Task.Delay(3000);
                    Console.Clear();
                } catch (FormatException) {
                    Console.WriteLine("Voce digitou um caracter invés de um número, Vamos tentar denovo");
                    await Task.Delay(3000);
                    Console.Clear();
                }

            }
        }
    }
}
