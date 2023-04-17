using System.Collections;
using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamentos
{
    public class TelaEquipamento : Tela //a classe Tela é a mãe da classe TelaEquipamento
    {
        public RepositorioEquipamento repositorioEquipamento = null;

        public string ApresentarMenuCadastroEquipamento()
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

        public void InserirNovoEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Inserindo Novo Equipamento: ");

            Equipamento novoEquipamento = ObterEquipamento();

            ArrayList erros = novoEquipamento.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);                
                return;
            }
            
            repositorioEquipamento.Inserir(novoEquipamento);

            ApresentarMensagem("Equipamento inserido com sucesso!", ConsoleColor.Green);
        }       

        public void EditarEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Editando Equipamento: ");

            bool temEquipamentos = VisualizarEquipamentos(false);

            if (temEquipamentos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEquipamento();

            Equipamento equipamentoAtualizado = ObterEquipamento();

            ArrayList erros = equipamentoAtualizado.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorioEquipamento.Editar(idSelecionado, equipamentoAtualizado);

            ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Excluindo Equipamento: ");

            bool temEquipamentosGravados = VisualizarEquipamentos(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEquipamento();

            repositorioEquipamento.Excluir(idSelecionado);

            ApresentarMensagem("Equipamento excluído com sucesso!", ConsoleColor.Green);
        }

        public bool VisualizarEquipamentos(bool mostrarCabecalho)
        {
            ArrayList listaEquipamentos = repositorioEquipamento.SelecionarTodos();

            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Equipamentos", "Visualizando Equipamentos: ");

            if (listaEquipamentos.Count == 0)
            {
                ApresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);
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

        public int EncontrarIdEquipamento()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Equipamento: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioEquipamento.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

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
