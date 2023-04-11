/** Requisito 1.1 
* Como funcionário, Junior quer ter a possibilidade 
* de registrar equipamentos

Critérios:

•  Deve ter um nome com no mínimo 6 caracteres;  
•  Deve ter um preço de aquisição;  
•  Deve ter um número de série;  
•  Deve ter uma data de fabricação;  
•  Deve ter uma fabricante; 

*/
/** Requisito 1.2 
* Como funcionário, Junior quer ter a possibilidade 
* de visualizar todos os equipamentos registrados em seu inventário

   Critérios:

    •  Deve mostrar o nome;  
    •  Deve mostrar o preço de aquisição;  
    •  Deve mostrar o número de série;  
    •  Deve mostrar a data de fabricação;  
    •  Deve mostrar o fabricante; 
*/
/** Requisito 1.3 
* Como funcionário, Junior quer ter a possibilidade 
* de editar um equipamento, sendo que ele possa editar todos os campos

   Critérios:

    •  Deve ter os mesmos critérios que o Requisito 1.1
*/
/** Requisito 1.4 
* 
* Como funcionário, Junior quer ter a possibilidade 
* de excluir um equipamento que esteja registrado.    
* 
*    •   A lista de equipamentos deve ser atualizada
*/
/** Requisito 2.1 
* 
* Como funcionário, Junior quer ter a possibilidade 
* de registrar os chamados de manutenções que são efetuadas nos equipamentos registrados    
* 
        •  Deve ter a título do chamado;  
        •  Deve ter a descrição do chamado;  
        •  Deve ter um equipamento;  
        •  Deve ter uma data de abertura;   
*/
/** Requisito 2.2 
* 
* Como funcionário, Junior quer ter a possibilidade de
* visualizar todos os chamados registrados para controle.   
* 
       •  Deve ter o id do chamado;  
       •  Deve ter a título do chamado;  
       •  Deve ter a descrição do chamado;  
       •  Deve ter um equipamento;  
       •  Deve ter uma data de abertura;   
*/
/** Requisito 2.3 
* 
* Como funcionário, Junior quer ter a possibilidade de
* editar um chamado que esteja registrado, sendo que ele possa editar todos os campos   
* 
        •  Deve ter os mesmos critérios que o Requisito 2.1  
*/
/** Requisito 2.4 
* 
* Como funcionário, Junior quer ter a possibilidade
* de excluir um chamado
* 
        •  A lista de chamados deve ser atualizada 
*/

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {               
        static void Main(string[] args)
        {
            //CadastroEquipamento.CadastrarAlgunsEquipamentosAutomaticamente();
            //CadastroChamado.CadastrarAlgunsChamadosAutomaticamente();

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string opcaoCadastroEquipamentos = CadastroEquipamento.ApresentarMenuCadastroEquipamento();

                    if (opcaoCadastroEquipamentos == "s")
                        continue;

                    CadastroEquipamento.CadastrarEquipamento(opcaoCadastroEquipamentos);
                }
                else if (opcao == "2")
                {
                    string opcaoCadastroChamados = CadastroChamado.ApresentarMenuCadastroChamado();

                    if (opcaoCadastroChamados == "s")
                        continue;

                    CadastroChamado.ControleChamados(opcaoCadastroChamados);
                }
            }
        }        

        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();

            Console.WriteLine();
        }

        static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Gestão de Equipamentos 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Equipamentos");

            Console.WriteLine("Digite 2 para Controlar Chamados");

            Console.WriteLine();

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}