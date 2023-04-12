using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamados
{
    public class RepositorioChamado
    {
        private static int ContadorDeChamado = 1;

        private static ArrayList listaChamados = new ArrayList();

        public static void Inserir(Chamado chamado)
        {
            chamado.id = ContadorDeChamado;

            listaChamados.Add(chamado);

            IncrementarIdChamado();
        }

        public static Chamado SelecionarPorId(int idSelecionado)
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

        public static void Editar(int id, Chamado chamadoAtualizado)
        {
            Chamado chamado = SelecionarPorId(id);

            chamado.titulo = chamadoAtualizado.titulo;
            chamado.descricao = chamadoAtualizado.descricao;
            chamado.dataAbertura = chamadoAtualizado.dataAbertura;
            chamado.equipamento = chamadoAtualizado.equipamento;
        }

        public static void Excluir(int idSelecionado)
        {
            Chamado chamado = SelecionarPorId(idSelecionado);

            listaChamados.Remove(chamado);
        }

        public static ArrayList SelecionarTodos()
        {
            return listaChamados;
        }
       
        public static void CadastrarAlgunsChamadosAutomaticamente()
        {
            Chamado chamado = new Chamado();

            chamado.id = ContadorDeChamado;
            chamado.titulo = "Impressão fraca";
            chamado.descricao = "Mesmo trocando o toner, impressão continua fraca";
            chamado.dataAbertura = "04/04/2023";
            chamado.equipamento = RepositorioEquipamento.SelecionarPorId(1);

            listaChamados.Add(chamado);

            ContadorDeChamado++;
        }

        #region Métodos Privados

        private static void IncrementarIdChamado()
        {
            ContadorDeChamado++;
        }



        #endregion

    }
}
