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
        static int ContadorDeEquipamento = 1;

        static int ContadorDeChamado = 1;

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

                    CadastroEquipamentos(opcaoCadastroEquipamentos);
                }
                else if (opcao == "2")
                {
                    string opcaoCadastroChamados = ApresentarMenuCadastroChamado();

                    if (opcaoCadastroChamados == "s")
                        continue;

                    ControleChamados(opcaoCadastroChamados);
                }
            }
        }

        #region Chamados
        static void ControleChamados(string opcaoCadastroChamados)
        {
            if (opcaoCadastroChamados == "1")
            {
                InserirNovoChamado();
            }
            else if (opcaoCadastroChamados == "2")
            {
                bool temChamados = VisualizarChamados(true);

                if (temChamados)
                    Console.ReadLine();
            }
            else if (opcaoCadastroChamados == "3")
            {
                EditarChamado();
            }
            else if (opcaoCadastroChamados == "4")
            {
                //Excluir um equipamento existente
                ExcluirChamado();
            }
        }

        static void ExcluirChamado()
        {
            throw new NotImplementedException();
        }

        static void EditarChamado()
        {
            throw new NotImplementedException();
        }

        static bool VisualizarChamados(bool v)
        {
            throw new NotImplementedException();
        }

        static void InserirNovoChamado()
        {
            MostrarCabecalho("Cadastro de Chamados", "Inserindo Novo Chamado: ");

            GravarChamado(ContadorDeChamado, "INSERIR");

            IncrementarIdChamado();

            ApresentarMensagem("Chamado inserido com sucesso!", ConsoleColor.Green);
        }

        static void IncrementarIdChamado()
        {
            ContadorDeChamado++;
        }

        static void GravarChamado(int id, string tipoOperacao)
        {
            VisualizarEquipamentos(false);

            Console.WriteLine();

            Console.Write("Digite o Id do equipamento para manutenção: ");
            int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            string dataAbertura = Console.ReadLine();

            if (tipoOperacao == "INSERIR")
            {
                //utilizado para inserção

                //listaIdsChamado.Add(id);
                //listaIdsEquipamentoChamado.Add(idEquipamentoChamado);
                //listaTitulosChamado.Add(titulo);
                //listaDescricoesChamado.Add(descricao);
                //listaDatasAberturaChamado.Add(dataAbertura);
            }
            else if (tipoOperacao == "EDITAR")
            {
                //utilizado para edição

                //int posicao = listaIdsChamado.IndexOf(id);
                //listaIdsChamado[posicao] = id;
                //listaTituloChamado[posicao] = titulo;
                //listaDescricoesChamado[posicao] = descricao;
                //listaDatasAberturaChamado[posicao] = dataAbertura;
            }
        }

        static string ApresentarMenuCadastroChamado()
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

        #endregion

        #region Equipamentos
        static void CadastroEquipamentos(string opcaoCadastroEquipamentos)
        {
            if (opcaoCadastroEquipamentos == "1")
            {
                InserirNovoEquipamento();
            }
            else if (opcaoCadastroEquipamentos == "2")
            {
                bool temEquipamentos = VisualizarEquipamentos(true);

                if (temEquipamentos)
                    Console.ReadLine();
            }
            else if (opcaoCadastroEquipamentos == "3")
            {
                EditarEquipamento();
            }
            else if (opcaoCadastroEquipamentos == "4")
            {
                //Excluir um equipamento existente
                ExcluirEquipamento();
            }
        }

        static void ExcluirEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Excluindo Equipamento: ");

            bool temEquipamentosGravados = VisualizarEquipamentos(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarEquipamento();

            int posicao = listaIdsEquipamento.IndexOf(idSelecionado);
            
            listaIdsEquipamento.RemoveAt(posicao);
            listaNomesEquipamento.RemoveAt(posicao);
            listaPrecosEquipamento.RemoveAt(posicao);
            listaNumerosSerieEquipamento.RemoveAt(posicao);
            listaDatasFabricaoEquipamento.RemoveAt(posicao);
            listaFabricanteEquipamento.RemoveAt(posicao);

            ApresentarMensagem("Equipamento excluído com sucesso!", ConsoleColor.Green);
        }

        static void EditarEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Editando Equipamento: ");

            bool temEquipamentosGravados = VisualizarEquipamentos(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarEquipamento();

            GravarEquipamento(idSelecionado, "EDITAR");                      

            ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);
        }

        static int EncontrarEquipamento()
        {
            int idSelecionado = 0;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Equipamento que deseja editar: ");
                
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                
                idInvalido = listaIdsEquipamento.Contains(idSelecionado) == false;

                if (idInvalido)                
                    ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);                

            } while (idInvalido);

            return idSelecionado;
        }

        static void GravarEquipamento(int id, string tipoOperacao)
        {
            string nome;
            bool nomeInvalido;

            do
            {
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
            
            if (tipoOperacao == "INSERIR")
            {
                //utilizado para inserção
                listaIdsEquipamento.Add(id);
                listaNomesEquipamento.Add(nome);
                listaPrecosEquipamento.Add(preco);
                listaNumerosSerieEquipamento.Add(numeroSerie);
                listaDatasFabricaoEquipamento.Add(dataFabricacao);
                listaFabricanteEquipamento.Add(fabricante);                
            }
            else if (tipoOperacao == "EDITAR")
            {
                //utilizado para edição
                int posicao = listaIdsEquipamento.IndexOf(id);

                listaIdsEquipamento[posicao] = id;
                listaNomesEquipamento[posicao] = nome;
                listaPrecosEquipamento[posicao] = preco;
                listaNumerosSerieEquipamento[posicao] = numeroSerie;
                listaDatasFabricaoEquipamento[posicao] = dataFabricacao;
                listaFabricanteEquipamento[posicao] = fabricante;
            }
        }

        static bool VisualizarEquipamentos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Equipamentos", "Visualizando Equipamentos: ");

            if (listaIdsEquipamento.Count == 0) 
            {
                ApresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);            
                return false;
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
            
            return true;
        }

        static void InserirNovoEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos", "Inserindo Novo Equipamento: ");

            GravarEquipamento(ContadorDeEquipamento, "INSERIR");

            IncrementarIdEquipamento();

            ApresentarMensagem("Equipamento inserido com sucesso!", ConsoleColor.Green);
        }

        static void IncrementarIdEquipamento()
        {
            ContadorDeEquipamento++;
        }

        #endregion

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