using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public class Tela
    {
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();

            Console.WriteLine();
        }

        public static void ApresentarErros(ArrayList erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (string erro in erros)
                Console.WriteLine(erro);

            Console.ResetColor();
            Console.ReadLine();
        }


    }
}
