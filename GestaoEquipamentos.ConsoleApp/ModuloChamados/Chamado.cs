using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamados
{
    public class Chamado : Entidade
    {        
        public string titulo;
        public string descricao;
        public string dataAbertura;

        public Equipamento equipamento; 

        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(titulo))
                erros.Add("O título é obrigatório");

            if (equipamento == null)
                erros.Add("O equipamento é obrigatório");

            return erros;
        }

        public void Atualizar(Chamado chamadoAtualizado)
        {
            titulo = chamadoAtualizado.titulo;
            descricao = chamadoAtualizado.descricao;
            dataAbertura = chamadoAtualizado.dataAbertura;
            equipamento = chamadoAtualizado.equipamento;
        }
    }
}
