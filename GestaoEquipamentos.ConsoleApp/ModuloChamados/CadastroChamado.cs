using GestaoEquipamentos.ConsoleApp.ModuloChamados;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp
{
    public class CadastroChamado
    {
        static int ContadorDeChamado = 1;       

        static ArrayList listaChamados = new ArrayList();

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

            Chamado chamado = SelecionarChamadoPorId(idSelecionado);

            listaChamados.Remove(chamado);
           
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

                idInvalido = SelecionarChamadoPorId(idSelecionado) == null;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

        private static Chamado SelecionarChamadoPorId(int idSelecionado)
        {
            Chamado chamado = null;

            foreach (Chamado c in listaChamados)
            {
                if (c.id == idSelecionado)
                {
                    chamado = c; 
                    break;
                }
            }

            return chamado;
        }

        static bool VisualizarChamados(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Controle de Chamados", "Visualizando Chamados: ");

            if (listaChamados.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum chamado cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}", "Id", "Título", "Equipamento", "Data de Abertura");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");


            foreach(Chamado c in listaChamados) 
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}",
                    c.id, c.titulo, c.equipamento.nome, c.dataAbertura);               
            }

            Console.ResetColor();

            return true;
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

            int idEquipamentoChamado = CadastroEquipamento.EncontrarIdEquipamento();

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            string dataAbertura = Console.ReadLine();

            if (tipoOperacao == "INSERIR")
            {
                Chamado chamado = new Chamado();
                chamado.id = id;
                chamado.titulo = titulo;
                chamado.descricao = descricao;
                chamado.dataAbertura = dataAbertura;
                chamado.equipamento = CadastroEquipamento.SelecionarEquipamentoPorId(idEquipamentoChamado);

                listaChamados.Add(chamado);
            }
            else if (tipoOperacao == "EDITAR")
            {
                Chamado chamado = SelecionarChamadoPorId(id);
                chamado.id = id;
                chamado.titulo = titulo;
                chamado.descricao = descricao;
                chamado.dataAbertura = dataAbertura;
                chamado.equipamento = CadastroEquipamento.SelecionarEquipamentoPorId(idEquipamentoChamado);
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
            Chamado chamado = new Chamado();

            chamado.id = ContadorDeChamado;
            chamado.titulo = "Impressão fraca";
            chamado.descricao = "Mesmo trocando o toner, impressão continua fraca";
            chamado.dataAbertura = "04/04/2023";
            chamado.equipamento = CadastroEquipamento.SelecionarEquipamentoPorId(1);

            listaChamados.Add(chamado);

            ContadorDeChamado++;
        }
    }
}
