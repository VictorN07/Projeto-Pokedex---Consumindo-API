using System.Net.Http;
using System.Threading.Tasks;
using Pokedex.Modelo;

namespace Program {
    class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("Vamos Começar? :)");
            try{
                await Menu.ExibirMenu();
                
            } catch (Exception ex) {
                Console.WriteLine($"ouve um Erro: {ex.Message}");
            }
            Console.WriteLine("Programa Finalizado");
        }
    }
}