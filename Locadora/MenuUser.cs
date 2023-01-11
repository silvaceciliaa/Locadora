namespace locadora
{
    public class MenuUser
    {
        public void OpcaoMenuUsuario(UsersFunctions functions)
        {
            bool loopMenuUsuario = true;

            while (loopMenuUsuario)
            {
                Console.WriteLine("(1) Ver listagem (2) Pesquisar (3) Alugar (4) Voltar");
                var opcaoMenuUsuario = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcaoMenuUsuario)
                {
                    case 1:
                        functions.MoviesCatalog();
                        break;
                    case 2:
                        functions.SearchMovies();
                        break;
                    case 3:
                        functions.Rent();
                        break;
                    case 4:
                        loopMenuUsuario = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}