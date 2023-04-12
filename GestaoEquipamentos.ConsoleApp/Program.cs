using GestaoEquipamentos.ConsoleApp.ModuloChamados;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {               
        static void Main(string[] args)
        {            
            RepositorioEquipamento.CadastrarAlgunsEquipamentosAutomaticamente();
            RepositorioChamado.CadastrarAlgunsChamadosAutomaticamente();                            

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string opcaoCadastroEquipamentos = TelaEquipamento.ApresentarMenuCadastroEquipamento();

                    if (opcaoCadastroEquipamentos == "s")
                        continue;

                    if (opcaoCadastroEquipamentos == "1")
                    {
                        TelaEquipamento.InserirNovoEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "2")
                    {
                        bool temEquipamentos = TelaEquipamento.VisualizarEquipamentos(true);

                        if (temEquipamentos)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroEquipamentos == "3")
                    {
                        TelaEquipamento.EditarEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "4")
                    {
                        TelaEquipamento.ExcluirEquipamento();
                    }
                }
                else if (opcao == "2")
                {
                    string opcaoCadastroChamados = TelaChamado.ApresentarMenuCadastroChamado();

                    if (opcaoCadastroChamados == "s")
                        continue;

                    if (opcaoCadastroChamados == "1")
                    {
                        TelaChamado.InserirNovoChamado();
                    }
                    else if (opcaoCadastroChamados == "2")
                    {
                        bool temChamados = TelaChamado.VisualizarChamados(true);

                        if (temChamados)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroChamados == "3")
                    {
                        TelaChamado.EditarChamado();
                    }
                    else if (opcaoCadastroChamados == "4")
                    {
                        TelaChamado.ExcluirChamado();
                    }
                }
            }
        }        

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

        static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Gestão de Equipamentos 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Equipamentos");

            Console.WriteLine("Digite 2 para Controlar Chamados");

            Console.WriteLine();

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
