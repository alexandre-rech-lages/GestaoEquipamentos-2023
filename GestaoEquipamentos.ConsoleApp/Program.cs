#region Requisitos
















#endregion

using System.Collections;

/** Requisito 1.1 
* Como funcionário, Junior quer ter a possibilidade 
* de registrar equipamentos

Critérios:

•  Deve ter um nome com no mínimo 6 caracteres;  
•  Deve ter um preço de aquisição;  
•  Deve ter um número de série;  
•  Deve ter uma data de fabricação;  
•  Deve ter uma fabricante; 

*//** Requisito 1.2 
* Como funcionário, Junior quer ter a possibilidade 
* de visualizar todos os equipamentos registrados em seu inventário

   Critérios:

    •  Deve mostrar o nome;  
    •  Deve mostrar o preço de aquisição;  
    •  Deve mostrar o número de série;  
    •  Deve mostrar a data de fabricação;  
    •  Deve mostrar o fabricante; 
*//** Requisito 1.3 
* Como funcionário, Junior quer ter a possibilidade 
* de editar um equipamento, sendo que ele possa editar todos os campos

   Critérios:

    •  Deve ter os mesmos critérios que o Requisito 1.1
*//** Requisito 1.4 
* 
* Como funcionário, Junior quer ter a possibilidade 
* de excluir um equipamento que esteja registrado.    
* 
*    •   A lista de equipamentos deve ser atualizada
*//** Requisito 2.1 
* 
* Como funcionário, Junior quer ter a possibilidade 
* de registrar os chamados de manutenções que são efetuadas nos equipamentos registrados    
* 
        •  Deve ter a título do chamado;  
        •  Deve ter a descrição do chamado;  
        •  Deve ter um equipamento;  
        •  Deve ter uma data de abertura;   
*//** Requisito 2.2 
* 
* Como funcionário, Junior quer ter a possibilidade de
* visualizar todos os chamados registrados para controle.   
* 
       •  Deve ter o id do chamado;  
       •  Deve ter a título do chamado;  
       •  Deve ter a descrição do chamado;  
       •  Deve ter um equipamento;  
       •  Deve ter uma data de abertura;   
*//** Requisito 2.3 
* 
* Como funcionário, Junior quer ter a possibilidade de
* editar um chamado que esteja registrado, sendo que ele possa editar todos os campos   
* 
        •  Deve ter os mesmos critérios que o Requisito 2.1  
*//** Requisito 2.4 
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
        static int id = 1;
        
        static ArrayList listaIdsEquipamento = new ArrayList();
        static ArrayList listaNomesEquipamento = new ArrayList();
        static ArrayList listaPrecosEquipamento = new ArrayList();
        static ArrayList listaNumerosSerieEquipamento = new ArrayList();
        static ArrayList listaDatasFabricaoEquipamento = new ArrayList();
        static ArrayList listaFabricanteEquipamento = new ArrayList();

        static void Main(string[] args)
        {
            while (true)
            {
                //apresentar o menu principal

                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string opcaoCadastroEquipamentos = ApresentarMenuCadastroEquipamento();

                    if (opcaoCadastroEquipamentos == "s")
                        continue;

                    if (opcaoCadastroEquipamentos == "1")
                    {
                        InserirNovoEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "2")
                    {
                        VisualizarEquipamentos();
                    }
                    else if (opcaoCadastroEquipamentos == "3")
                    {
                        //Editar um equipamento existente
                    }
                    else if (opcaoCadastroEquipamentos == "4")
                    {
                        //Excluir um equipamento existente
                    }
                }
                else if (opcao == "2")
                {
                    //apresentar um submenu com o CRUD de Chamados
                }
            }
        }       

        static void VisualizarEquipamentos()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Visualizando Equipamentos: ");

            if (listaIdsEquipamento.Count == 0) 
            {
                ApresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);            
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Nome", "Fabricante");

            Console.WriteLine("---------------------------------------------------------------------------------------"  );

            for (int i = 0; i < listaIdsEquipamento.Count; i++)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}",
                    listaIdsEquipamento[i], listaNomesEquipamento[i], listaFabricanteEquipamento[i]);
            }

            Console.ResetColor();
            Console.ReadLine();
        }

        static void InserirNovoEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Inserindo Novo Equipamento: ");

            string nome;
            bool nomeInvalido;

            do {

                nomeInvalido = false;
                Console.Write("Digite o nome do Equipamento: ");
                nome = Console.ReadLine();

                if (nome.Length <= 6)
                {
                    nomeInvalido = true;
                    ApresentarMensagem("Nome inválido. Informe no mínimo 6 letras", ConsoleColor.Red);                  
                }
            }
            while (nomeInvalido);

            Console.Write("Digite o preco do Equipamento: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o número de série: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação: ");
            string dataFabricacao = Console.ReadLine();

            Console.Write("Digite o Fabricante: ");
            string fabricante = Console.ReadLine();
            
            listaIdsEquipamento.Add(id);
            listaNomesEquipamento.Add(nome);
            listaPrecosEquipamento.Add(preco);
            listaNumerosSerieEquipamento.Add(numeroSerie);
            listaDatasFabricaoEquipamento.Add(dataFabricacao);
            listaFabricanteEquipamento.Add(fabricante);

            id++;

            ApresentarMensagem("Equipamento inserido com sucesso!", ConsoleColor.Green);           
        }

        static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();

            Console.WriteLine();
        }

        static string ApresentarMenuCadastroEquipamento()
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