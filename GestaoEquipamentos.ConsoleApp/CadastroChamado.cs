using System.Collections;

namespace GestaoEquipamentos.ConsoleApp
{
    public class CadastroChamado
    {
        static int ContadorDeChamado = 1;

        static ArrayList listaIdsChamado = new ArrayList();
        static ArrayList listaTitulosChamado = new ArrayList();
        static ArrayList listaIdsEquipamentoChamado = new ArrayList();
        static ArrayList listaDescricoesChamado = new ArrayList();
        static ArrayList listaDatasAberturaChamado = new ArrayList();

        public static void ControleChamados(string opcaoCadastroChamados)
        {
            if (opcaoCadastroChamados == "1")
            {
                InserirNovoChamado();
            }
            else if (opcaoCadastroChamados == "2")
            {
                bool temChamados = VisualizarChamados(true);

                if (temChamados)
                    Console.ReadLine();
            }
            else if (opcaoCadastroChamados == "3")
            {
                EditarChamado();
            }
            else if (opcaoCadastroChamados == "4")
            {
                //Excluir um equipamento existente
                ExcluirChamado();
            }
        }

        static void ExcluirChamado()
        {
            Program.MostrarCabecalho("Controle de Chamados", "Excluindo Chamado: ");

            bool temChamados = VisualizarChamados(false);

            if (temChamados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarChamado();

            int posicao = listaIdsChamado.IndexOf(idSelecionado);

            listaIdsChamado.RemoveAt(posicao);
            listaTitulosChamado.RemoveAt(posicao);
            listaDescricoesChamado.RemoveAt(posicao);
            listaIdsEquipamentoChamado.RemoveAt(posicao);
            listaDatasAberturaChamado.RemoveAt(posicao);

            Program.ApresentarMensagem("Chamado excluído com sucesso!", ConsoleColor.Green);
        }

        static void EditarChamado()
        {
            Program.MostrarCabecalho("Controle de Chamados", "Editando Chamado: ");

            bool temChamados = VisualizarChamados(false);

            if (temChamados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarChamado();

            GravarChamado(idSelecionado, "EDITAR");

            Program.ApresentarMensagem("Chamado editado com sucesso!", ConsoleColor.Green);
        }

        static int EncontrarChamado()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Chamado: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = listaIdsChamado.Contains(idSelecionado) == false;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

        static bool VisualizarChamados(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Controle de Chamados", "Visualizando Chamados: ");

            if (listaIdsChamado.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum chamado cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}", "Id", "Título", "Equipamento", "Data de Abertura");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");


            for (int i = 0; i < listaIdsChamado.Count; i++)
            {
                string nomeEquipamento = ObterNomeEquipamento((int)listaIdsEquipamentoChamado[i]);

                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}",
                    listaIdsChamado[i], listaTitulosChamado[i], nomeEquipamento, listaDatasAberturaChamado[i]);
            }

            Console.ResetColor();

            return true;
        }

        private static string ObterNomeEquipamento(int id)
        {
            int posicao = CadastroEquipamento.listaIdsEquipamento.IndexOf(id);

            string nomeEquipamento = (string)CadastroEquipamento.listaNomesEquipamento[posicao];

            return nomeEquipamento;
        }

        static void InserirNovoChamado()
        {
            Program.MostrarCabecalho("Cadastro de Chamados", "Inserindo Novo Chamado: ");

            GravarChamado(ContadorDeChamado, "INSERIR");

            IncrementarIdChamado();

            Program.ApresentarMensagem("Chamado inserido com sucesso!", ConsoleColor.Green);
        }

        static void IncrementarIdChamado()
        {
            ContadorDeChamado++;
        }

        static void GravarChamado(int id, string tipoOperacao)
        {
            CadastroEquipamento.VisualizarEquipamentos(false);

            Console.WriteLine();

            int idEquipamentoChamado = CadastroEquipamento.EncontrarEquipamento();

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            string dataAbertura = Console.ReadLine();

            if (tipoOperacao == "INSERIR")
            {
                //utilizado para inserção
                listaIdsChamado.Add(id);
                listaIdsEquipamentoChamado.Add(idEquipamentoChamado);
                listaTitulosChamado.Add(titulo);
                listaDescricoesChamado.Add(descricao);
                listaDatasAberturaChamado.Add(dataAbertura);
            }
            else if (tipoOperacao == "EDITAR")
            {
                //utilizado para edição

                int posicao = listaIdsChamado.IndexOf(id);
                listaIdsChamado[posicao] = id;
                listaIdsEquipamentoChamado[posicao] = idEquipamentoChamado;
                listaTitulosChamado[posicao] = titulo;
                listaDescricoesChamado[posicao] = descricao;
                listaDatasAberturaChamado[posicao] = dataAbertura;
            }
        }

        public static string ApresentarMenuCadastroChamado()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Cadastro de Chamados");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir um Novo Chamado");

            Console.WriteLine("Digite 2 para Visulizar Chamados");

            Console.WriteLine("Digite 3 para Editar Chamados");

            Console.WriteLine("Digite 4 para Excluir Chamados");

            Console.WriteLine();

            Console.WriteLine("Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void CadastrarAlgunsChamadosAutomaticamente()
        {
            listaIdsChamado.Add(ContadorDeChamado);
            listaIdsEquipamentoChamado.Add(CadastroEquipamento.listaIdsEquipamento[0]);
            listaTitulosChamado.Add("Impressão fraca");
            listaDescricoesChamado.Add("Mesmo trocando o toner, impressão continua fraca");
            listaDatasAberturaChamado.Add("04/04/2023");

            ContadorDeChamado++;
        }
    }
}
