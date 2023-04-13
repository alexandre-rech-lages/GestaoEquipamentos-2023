using GestaoEquipamentos.ConsoleApp.ModuloChamados;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;

namespace GestaoEquipamentos.ConsoleApp
{  
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
            repositorioEquipamento.CadastrarAlgunsEquipamentosAutomaticamente();

            RepositorioChamado repositorioChamado = new RepositorioChamado();
            repositorioChamado.repositorioEquipamento = repositorioEquipamento;

            repositorioChamado.CadastrarAlgunsChamadosAutomaticamente();

            TelaEquipamento telaEquipamento = new TelaEquipamento();
            telaEquipamento.repositorioEquipamento = repositorioEquipamento;

            TelaChamado telaChamado = new TelaChamado();
            telaChamado.repositorioEquipamento = repositorioEquipamento;
            telaChamado.repositorioChamado = repositorioChamado;
            telaChamado.telaEquipamento = telaEquipamento;

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string opcaoCadastroEquipamentos = telaEquipamento.ApresentarMenuCadastroEquipamento();

                    if (opcaoCadastroEquipamentos == "s")
                        continue;

                    if (opcaoCadastroEquipamentos == "1")
                    {
                        telaEquipamento.InserirNovoEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "2")
                    {
                        bool temEquipamentos = telaEquipamento.VisualizarEquipamentos(true);

                        if (temEquipamentos)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroEquipamentos == "3")
                    {
                        telaEquipamento.EditarEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "4")
                    {
                        telaEquipamento.ExcluirEquipamento();
                    }
                }
                else if (opcao == "2")
                {
                    string opcaoCadastroChamados = telaChamado.ApresentarMenuCadastroChamado();

                    if (opcaoCadastroChamados == "s")
                        continue;

                    if (opcaoCadastroChamados == "1")
                    {
                        telaChamado.InserirNovoChamado();
                    }
                    else if (opcaoCadastroChamados == "2")
                    {
                        bool temChamados = telaChamado.VisualizarChamados(true);

                        if (temChamados)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroChamados == "3")
                    {
                        telaChamado.EditarChamado();
                    }
                    else if (opcaoCadastroChamados == "4")
                    {
                        telaChamado.ExcluirChamado();
                    }
                }
            }
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
