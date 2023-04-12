using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamentos
{
    public class TelaEquipamento
    {

        /// <summary>
        /// Esta função é responsável por apresentar as funcionalidades no cadastro de equipamentos
        /// </summary>
        /// <returns>A opção escolhida (1-Inserir, 2-Visualizar Todos, 3-Editar, 4-Excluir e S para sair)</returns>
        public static string ApresentarMenuCadastroEquipamento()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Cadastro de Equipamentos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir um Novo Equipamento");

            Console.WriteLine("Digite 2 para Visulizar Equipamentos");

            Console.WriteLine("Digite 3 para Editar Equipamentos");

            Console.WriteLine("Digite 4 para Excluir Equipamentos");

            Console.WriteLine();

            Console.WriteLine("Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        /// <summary>
        /// Esta função é responsável por fazer a interação do usuário no processo de criação de um equipamento
        /// </summary>
        public static void InserirNovoEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Inserindo Novo Equipamento: ");

            Equipamento novoEquipamento = ObterEquipamento();

            ArrayList erros = novoEquipamento.Validar();

            if (erros.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)                
                    Console.WriteLine(erro);                

                Console.ResetColor();

                return;
            }

            RepositorioEquipamento.Inserir(novoEquipamento);

            Program.ApresentarMensagem("Equipamento inserido com sucesso!", ConsoleColor.Green);
        }

        public static void EditarEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Editando Equipamento: ");

            bool temEquipamentos = VisualizarEquipamentos(false);

            if (temEquipamentos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEquipamento();

            Equipamento equipamentoAtualizado = ObterEquipamento();

            ArrayList erros = equipamentoAtualizado.Validar();

            if (erros.Count > 0)
            {
                foreach (string erro in erros)
                    Program.ApresentarMensagem(erro, ConsoleColor.Red);

                return;
            }

            RepositorioEquipamento.Editar(idSelecionado, equipamentoAtualizado);

            Program.ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);
        }

        public static void ExcluirEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Excluindo Equipamento: ");

            bool temEquipamentosGravados = VisualizarEquipamentos(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEquipamento();

            RepositorioEquipamento.Excluir(idSelecionado);

            Program.ApresentarMensagem("Equipamento excluído com sucesso!", ConsoleColor.Green);
        }

        public static bool VisualizarEquipamentos(bool mostrarCabecalho)
        {
            ArrayList listaEquipamentos = RepositorioEquipamento.SelecionarTodos();

            if (mostrarCabecalho)
                Program.MostrarCabecalho("Cadastro de Equipamentos", "Visualizando Equipamentos: ");

            if (listaEquipamentos.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Nome", "Fabricante");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (Equipamento e in listaEquipamentos)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", e.id, e.nome, e.fabricante);
            }

            Console.ResetColor();

            return true;
        }

        public static int EncontrarIdEquipamento()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Equipamento: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = RepositorioEquipamento.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

        #region métodos privados

        private static Equipamento ObterEquipamento()
        {
            Equipamento equipamento = new Equipamento();

            Console.Write("Digite o nome do Equipamento: ");
            equipamento.nome = Console.ReadLine();

            Console.Write("Digite o preco do Equipamento: ");
            equipamento.preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o número de série: ");
            equipamento.numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação: ");
            equipamento.dataFabricacao = Console.ReadLine();

            Console.Write("Digite o Fabricante: ");
            equipamento.fabricante = Console.ReadLine();

            return equipamento;
        }


        #endregion
    }
}
