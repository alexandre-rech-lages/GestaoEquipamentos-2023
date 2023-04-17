using GestaoEquipamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamentos
{
    public class Equipamento : Entidade
    {        
        public string nome;
        public decimal preco;
        public string numeroSerie;
        public string dataFabricacao;
        public string fabricante;

        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (nome.Length <= 6)            
                erros.Add("Nome inválido. Informe no mínimo 6 letras");            

            if (fabricante.Length <= 6)            
                erros.Add("Nome inválido. Informe no mínimo 6 letras");            

            if (numeroSerie.IndexOf("-") < 0)            
                erros.Add("Número de série inválido. Informe um número com \"-\" ");            

            return erros;
        }

        public override void Atualizar(Entidade equipamentoAtualizado)
        {
            Equipamento equipamento = (Equipamento)equipamentoAtualizado;

            nome = equipamento.nome;
            preco = equipamento.preco;
            numeroSerie = equipamento.numeroSerie;
            dataFabricacao = equipamento.dataFabricacao;
            fabricante = equipamento.fabricante;
        }
    }
}
