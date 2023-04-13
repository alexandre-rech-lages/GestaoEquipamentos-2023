using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamados
{
    public class RepositorioChamado : Repositorio
    {
        public RepositorioEquipamento repositorioEquipamento = null;

        public void Inserir(Chamado chamado)
        {
            chamado.id = ContadorDeId;

            listaRegistros.Add(chamado);

            IncrementarId();
        }

        public Chamado SelecionarPorId(int idSelecionado)
        {
            Chamado chamado = null;

            foreach (Chamado c in listaRegistros)
            {
                if (c.id == idSelecionado)
                {
                    chamado = c;
                    break;
                }
            }

            return chamado;
        }

        public void Editar(int id, Chamado chamadoAtualizado)
        {
            Chamado chamado = SelecionarPorId(id);

            chamado.titulo = chamadoAtualizado.titulo;
            chamado.descricao = chamadoAtualizado.descricao;
            chamado.dataAbertura = chamadoAtualizado.dataAbertura;
            chamado.equipamento = chamadoAtualizado.equipamento;
        }

        public void Excluir(int idSelecionado)
        {
            Chamado chamado = SelecionarPorId(idSelecionado);

            listaRegistros.Remove(chamado);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }
       
        public void CadastrarAlgunsChamadosAutomaticamente()
        {
            Chamado chamado = new Chamado();

            chamado.id = ContadorDeId;
            chamado.titulo = "Impressão fraca";
            chamado.descricao = "Mesmo trocando o toner, impressão continua fraca";
            chamado.dataAbertura = "04/04/2023";
            chamado.equipamento = repositorioEquipamento.SelecionarPorId(1);

            listaRegistros.Add(chamado);

            ContadorDeId++;
        }
       
    }
}
