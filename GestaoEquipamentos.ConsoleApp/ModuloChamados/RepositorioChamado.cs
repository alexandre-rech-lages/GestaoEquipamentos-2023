using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamados
{
    public class RepositorioChamado : Repositorio
    {
        public RepositorioEquipamento repositorioEquipamento = null;

        public Chamado Chamados
        {
            get => default;
            set
            {
            }
        }

        public void CadastrarAlgunsChamadosAutomaticamente()
        {
            Chamado chamado = new Chamado();

            chamado.id = ContadorDeId;
            chamado.titulo = "Impressão fraca";
            chamado.descricao = "Mesmo trocando o toner, impressão continua fraca";
            chamado.dataAbertura = "04/04/2023";
            chamado.equipamento = (Equipamento) repositorioEquipamento.SelecionarPorId(1);

            listaRegistros.Add(chamado);

            ContadorDeId++;
        }
       
    }
}
