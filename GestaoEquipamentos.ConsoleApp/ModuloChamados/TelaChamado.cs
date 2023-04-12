using GestaoEquipamentos.ConsoleApp.ModuloChamados;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp
{
    public class TelaChamado
    {       
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
        
        public static void InserirNovoChamado()
        {
            Program.MostrarCabecalho("Cadastro de Chamados", "Inserindo Novo Chamado: ");

            Chamado chamado = ObterChamado();

            ArrayList erros = chamado.Validar();

            if (erros.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)                
                    Console.WriteLine( erro );
                
                Console.ResetColor();

                return;
            }
            
            RepositorioChamado.Inserir(chamado);

            Program.ApresentarMensagem("Chamado inserido com sucesso!", ConsoleColor.Green);
        }

        public static void EditarChamado()
        {
            Program.MostrarCabecalho("Controle de Chamados", "Editando Chamado: ");

            bool temChamados = VisualizarChamados(false);

            if (temChamados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdChamado();

            Chamado chamadoAtualizado = ObterChamado();

            ArrayList erros = chamadoAtualizado.Validar();

            if (erros.Count > 0)
            {
                foreach (string erro in erros)
                    Program.ApresentarMensagem(erro, ConsoleColor.Red);

                return;
            }

            RepositorioChamado.Editar(idSelecionado, chamadoAtualizado);

            Program.ApresentarMensagem("Chamado editado com sucesso!", ConsoleColor.Green);
        }

        public static void ExcluirChamado()
        {
            Program.MostrarCabecalho("Controle de Chamados", "Excluindo Chamado: ");

            bool temChamados = VisualizarChamados(false);

            if (temChamados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdChamado();

            RepositorioChamado.Excluir(idSelecionado);

            Program.ApresentarMensagem("Chamado excluído com sucesso!", ConsoleColor.Green);
        }

        public static bool VisualizarChamados(bool mostrarCabecalho)
        {
            ArrayList listaChamados = RepositorioChamado.SelecionarTodos();

            if (mostrarCabecalho)
                Program.MostrarCabecalho("Controle de Chamados", "Visualizando Chamados: ");

            if (listaChamados.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum chamado cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}", "Id", "Título", "Equipamento", "Fabricante", "Data de Abertura");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");


            foreach (Chamado c in listaChamados)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}",
                    c.id, c.titulo, c.equipamento.nome, c.equipamento.fabricante, c.dataAbertura);
            }

            Console.ResetColor();

            return true;
        }

        #region métodos privados

        private static Chamado ObterChamado()
        {
            TelaEquipamento.VisualizarEquipamentos(false);

            Console.WriteLine();

            Chamado chamado = new Chamado();

            int idEquipamento = TelaEquipamento.EncontrarIdEquipamento();
            chamado.equipamento = RepositorioEquipamento.SelecionarPorId(idEquipamento);

            Console.Write("Digite o título do chamado: ");
            chamado.titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            chamado.descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            chamado.dataAbertura = Console.ReadLine();

            return chamado;
        }
        private static int EncontrarIdChamado()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Chamado: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = RepositorioChamado.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }
      
        #endregion
    }
}
