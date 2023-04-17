namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public class Entidade 
    {
        public int id;

        //Virtual Validar 

        //Virtual Atualizar
        public virtual void Atualizar(Entidade registroAtualizado)
        {
            id = registroAtualizado.id;
        }
    }
}