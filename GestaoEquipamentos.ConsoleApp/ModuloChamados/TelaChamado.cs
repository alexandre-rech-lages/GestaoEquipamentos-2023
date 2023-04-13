using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloChamados;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp
{
    public class TelaChamado : Tela
    {
        public RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
        public RepositorioChamado repositorioChamado = new RepositorioChamado();

        public TelaEquipamento telaEquipamento = null;

        public string ApresentarMenuCadastroChamado()
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
        
        public void InserirNovoChamado()
        {
            MostrarCabecalho("Cadastro de Chamados", "Inserindo Novo Chamado: ");

            Chamado chamado = ObterChamado();

            ArrayList erros = chamado.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);

                return;
            }

            repositorioChamado.Inserir(chamado);

            ApresentarMensagem("Chamado inserido com sucesso!", ConsoleColor.Green);
        }
       
        public void EditarChamado()
        {
            MostrarCabecalho("Controle de Chamados", "Editando Chamado: ");

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
                    ApresentarMensagem(erro, ConsoleColor.Red);

                return;
            }

            repositorioChamado.Editar(idSelecionado, chamadoAtualizado);

            ApresentarMensagem("Chamado editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirChamado()
        {
            MostrarCabecalho("Controle de Chamados", "Excluindo Chamado: ");

            bool temChamados = VisualizarChamados(false);

            if (temChamados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdChamado();

            repositorioChamado.Excluir(idSelecionado);

            ApresentarMensagem("Chamado excluído com sucesso!", ConsoleColor.Green);
        }

        public bool VisualizarChamados(bool mostrarCabecalho)
        {
            ArrayList listaChamados = repositorioChamado.SelecionarTodos();

            if (mostrarCabecalho)
                MostrarCabecalho("Controle de Chamados", "Visualizando Chamados: ");

            if (listaChamados.Count == 0)
            {
                ApresentarMensagem("Nenhum chamado cadastrado!", ConsoleColor.DarkYellow);
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

        private Chamado ObterChamado()
        {
            telaEquipamento.VisualizarEquipamentos(false);

            Console.WriteLine();

            Chamado chamado = new Chamado();

            int idEquipamento = telaEquipamento.EncontrarIdEquipamento();
            chamado.equipamento = repositorioEquipamento.SelecionarPorId(idEquipamento);

            Console.Write("Digite o título do chamado: ");
            chamado.titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            chamado.descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            chamado.dataAbertura = Console.ReadLine();

            return chamado;
        }
        private int EncontrarIdChamado()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Chamado: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioChamado.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }
      
        #endregion
    }
}
