using AppBancoDominio;
using AppBancoDLL;
using MySql.Data.MySqlClient;
using System;
using AppBandoADO;

namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {
            int Opcao;

            do
            {
                var banco = new Banco();
                var usuarioDAO = new UsuarioDAO();
                var usuario = new Usuario();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------ AppBanco ------------");
                Console.WriteLine("-     0 - Cadastrar Usuario      -");
                Console.WriteLine("-     1 - Editar Usuario         -");
                Console.WriteLine("-     2 - Excluir Usuario        -");
                Console.WriteLine("-     3 - Listar Usuario         -");
                Console.WriteLine("-     4 - Sair                   -");
                Console.WriteLine("----------------------------------");

                Console.WriteLine("Qual opção você deseja?");
                Console.ForegroundColor = ConsoleColor.Red;
                Opcao = int.Parse(Console.ReadLine());

                if (Opcao == 0) //cadastrar
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o nome do usuário");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.NomeUsu = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o cargo");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.Cargo = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite a data nascimento");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.DataNasc = DateTime.Parse(Console.ReadLine());

                    new UsuarioDAO().Insert(usuario);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Usuário cadastrado com sucesso! Digite 3 para conferir o resultado :D");
                }
                else if (Opcao == 1) //editar
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o id do usuário que deseja alterar");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.IdUsu = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o novo nome do usuário");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.NomeUsu = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o novo cargo");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.Cargo = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite a nova data nascimento");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.DataNasc = DateTime.Parse(Console.ReadLine());

                    new UsuarioDAO().Atualizar(usuario);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Usuário atualizado com sucesso! Digite 3 para conferir o resultado :D");
                }
                else if (Opcao == 2) //excluir
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o id do usuário que deseja excluir");
                    Console.ForegroundColor = ConsoleColor.Red;
                    usuario.IdUsu = int.Parse(Console.ReadLine());

                    new UsuarioDAO().Excluir(usuario.IdUsu);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Usuário excluido com sucesso! Digite 3 para conferir o resultado :D");
                }
                else if (Opcao == 3) //listar
                {
                    var leitor = usuarioDAO.Listar();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var usuarios in leitor)
                    {
                        Console.WriteLine("Id: {0} , Nome: {1}, Cargo: {2}, Data: {3}", usuarios.IdUsu, usuarios.NomeUsu, usuarios.Cargo, usuarios.DataNasc);
                    };
                    Console.ReadLine();
                }
                else // o usuário não escolheu nenhuma das opções
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, escolha uma das seguintes opções: 0, 1, 2, 3 ou 4");
                }

            } while (Opcao != 4);
        }
    }
}

//código para atualizar registros
//string strAtualiza = "update tbUsuario set NomeUsu='MeAchoEsperto' where idUsu=2;";
//MySqlCommand comandoAtualiza = new MySqlCommand(strAtualiza, conexao);
//comandoAtualiza.ExecuteNonQuery();


//código para apagar registros
//MySqlCommand comandoApagar = new MySqlCommand("delete from tbUsuario where idUsu=2;", conexao);
//comandoApagar.ExecuteNonQuery();

