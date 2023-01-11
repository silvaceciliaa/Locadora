using System;
using locadora;

namespace locadora
{
    public class MenuAdmin
    {
        public int User { get; set; } = 1501;
        public int Password { get; set; } = 4321;

        public void LoginAdmin(UsersFunctions functions)
        {
            bool loopLoginMenu = true;

            while (loopLoginMenu)
            {
                Console.WriteLine("(1) Login (2) Voltar");
                var inputMenuLogin = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (inputMenuLogin)
                {
                    case 1:
                        LoginIn(functions);
                        break;
                    case 2:
                        loopLoginMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
        public void LoginIn(UsersFunctions functions)
        {
            Console.WriteLine("Usuário: ");
            int inputUser = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Senha: ");
            int inputPassword = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (inputUser != User || inputPassword != Password)
            {
                Console.WriteLine("Acesso não autorizado");
            }
            else
            {
                Logged(functions);
            }
        }
        public void Logged(UsersFunctions functions)
        {
            bool loopMenuAdmin = true;

            while (loopMenuAdmin)
            {
                Console.WriteLine("(1) Adicionar filme (2) Ver catálogo (3) Devolver (4) Pesquisar (5) Excluir (6) Alugar (7) Aumentar quantidade de filmes (8) Lista de Clientes (9)Voltar");
                var opcaoMenuAdmin = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcaoMenuAdmin)
                {
                    case 1:
                        functions.AddMovie();
                        break;
                    case 2:
                        functions.MoviesCatalog();
                        break;
                    case 3:
                        functions.ReturnMovie();
                        break;
                    case 4:
                        functions.SearchMovies();
                        break;
                    case 5:
                        functions.Remove();
                        break;
                    case 6:
                        functions.Rent();
                        break;
                    case 7:
                        functions.UptadeQuantity();
                        break;
                    case 8:
                        functions.ClientsList();
                        break;
                    case 9:
                        loopMenuAdmin = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
