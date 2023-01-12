using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Movies;
using Locadora.Clients;

namespace locadora
{
    public class UsersFunctions
    {
        public List<Movie> Movies { get; set; }
        public List<Client> Clients { get; set; }


        public UsersFunctions()
        {
            Movies = new List<Movie>();
            Clients = new List<Client>();
        }
        public void AddMovie()
        {
            var movie = new Movie();
            var validator = new MovieValidators();

            Console.WriteLine("Título: ");
            movie.Title = Console.ReadLine();
            validator.InputTitleValidator(movie);

            Console.WriteLine("Diretor: ");
            movie.Director = Console.ReadLine();
            validator.InputDirectorValidator(movie);

            Console.WriteLine("Data de lançamento: ");
            validator.InputReleaseYearValidator(movie);

            Console.WriteLine("Quantidade: ");
            validator.InputQuantityValidator(movie);

            var lastMovie = Movies.LastOrDefault();
            movie.Id = lastMovie is null ? 0 : lastMovie.Id + 1;

            Console.Clear();
            Movies.Add(movie);
            Console.WriteLine("Filme adicionado!");
        }

        public void MoviesCatalog()
        {
            if (Movies.Any())
            {
                foreach (var item in Movies)
                {
                    item.Catalog();
                }
            }
            else
            {
                Console.WriteLine("Não há filmes ainda");
            }
        }
        public void ClientsList()
        {
            if (Clients.Any())
            {
                foreach (var item in Clients)
                {
                    item.ListOfClients();
                }
            }
            else
            {
                Console.WriteLine("Não há nenhum cliente ainda");
            }
        }
        public void Rent()
        {
            if (Movies.Any())
            {
                var moviesToRent = Movies.Where(x => x.QuantityAvailable >= 1);

                if (moviesToRent.Any())
                {
                    Console.WriteLine("Digite o código do filme que deseja alugar: ");
                    int movieToBeRented = int.Parse(Console.ReadLine());
                    var rentMovie = Movies.Where(x => x.Id == movieToBeRented && x.QuantityAvailable >= 1);
                    Console.Clear();

                    if (rentMovie != null && rentMovie.Any())
                    {
                        foreach (var item in rentMovie)
                        {
                            item.QuantityAvailable--;
                        }
                        Console.WriteLine("Você tem cógido de cliente? (S)Sim (N)Não");
                        string receberCodigoCliente = Console.ReadLine().ToUpper();

                        if(receberCodigoCliente == "S")
                        {
                            FindClients();
                            
                        }

                        else if(receberCodigoCliente == "N")
                        {
                            AddClients();

                        }
                    }
                    else
                    {
                        Console.WriteLine("Filme não encontrado");
                    }
                }
                else
                {
                    Console.WriteLine("Não há filmes disponíveis");
                }
            }
            else
            {
                Console.WriteLine("Não há filmes cadastrados");
            }
        }
        public void SearchMovies()
        {
            if (Movies.Any())
            {
                Console.WriteLine("Pesquise: ");
                var str = Console.ReadLine();
                str = str.First().ToString().ToUpper() + str.Substring(1);
                var pesquisas = Movies.Where(x => x.Id.ToString() == str || x.Title == str ||  x.Director == str || x.ReleaseYear.ToString("dyyyy") == str).ToList();
                Console.Clear();

                if (pesquisas != null && pesquisas.Any())
                {
                    foreach (var item in pesquisas)
                    {
                        item.Catalog();
                    }
                }
                else
                {
                    Console.WriteLine("Não encontrado");
                }
            }
            else
            {
                Console.WriteLine("Não há filmes disponíveis para alugar");
            }
        }
        public void FindClients()
        {
            if (Clients.Any())
            {
                Console.WriteLine("Digite seu código: ");
                var str = Console.ReadLine();
                str = str.First().ToString().ToUpper() + str.Substring(1);
                var pesquisas = Clients.Where(x => x.IdClient.ToString() == str).ToList();
                Console.Clear();

                if (pesquisas != null && pesquisas.Any())
                {
                    foreach (var item in pesquisas)
                    {
                        item.ListOfClients();
                    }
                }
                else
                {
                    Console.WriteLine("Não encontrado");
                }
            }
            else
            {
                Console.WriteLine("Não há clientes cadastrados");
            }
        }
        public void ReturnMovie()
        {
            if (Movies.Any())
            {
                Console.WriteLine("Digite o ID do filme que você deseja devolver: ");
                int movieReturned = int.Parse(Console.ReadLine());
                Console.Clear();
                var returnMovie = Movies.Where(x => x.Id == movieReturned);

                if (returnMovie != null && returnMovie.Any())
                {
                    
                    foreach (var item in returnMovie)
                    {
                        item.QuantityAvailable = +1;
                    }
                    Console.WriteLine("Filme devolvido");
                }
                else
                {
                    Console.WriteLine("Não encontrado");
                }
            }
        }
        public void UptadeQuantity()
        {
            int updateOut;
            if (Movies.Any())
            {
                Console.WriteLine("Digite o código do filme que você deseja mudar a quantidade: ");
                int updatedMovieQ = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Digite a quantidade que deseja aumentar: ");
                var quantityUpdate = Console.ReadLine();
                var updateMovieQ = Movies.Where(x => x.Id == updatedMovieQ);
                Console.Clear();

                while (!int.TryParse(quantityUpdate, out updateOut) || updateOut < 0)
                {
                    Console.WriteLine("Resposta inválida. Adicione um número");
                    quantityUpdate = Console.ReadLine();
                }
                if (updateMovieQ != null && updateMovieQ.Any())
                {
                    foreach (var item in updateMovieQ)
                    {
                        item.QuantityAvailable = item.QuantityAvailable + updateOut;
                        item.TotalQuantity = item.TotalQuantity + updateOut;
                        break;
                    }
                    Console.WriteLine("Quantidade aumentada");
                }
                else
                {
                    Console.WriteLine("Não encontrado");
                }
            }
            else
            {
                Console.WriteLine("Nenhum filme foi cadastrado");
            }
        }
        public void Remove()
        {
            if (Movies.Any())
            {
                Console.WriteLine("Digite o código do filme que você deseja excluir: ");
                int deletedMovie = int.Parse(Console.ReadLine());
                Console.Clear();
                var deleteMovie = Movies.Where(x => x.Id == deletedMovie);
                Console.Clear();

                if (deleteMovie != null && deleteMovie.Any())
                {
                    foreach (var item in deleteMovie)
                    {
                        Movies.Remove(item);
                        break;
                    }
                    Console.WriteLine("Filme excluído");
                }
                else
                {
                    Console.WriteLine("Não encontrado");
                }
            }
            else
            {
                Console.WriteLine("Nenhum filme foi cadastrado");
            }
        }

        public void AddClients()
        {
            var validators = new ClientValidators();
            var client = new Client();
            Console.WriteLine("Digite o seu nome para proseguir: ");
            validators.InputClientNameValidator(client);

            var lastClient = Clients.LastOrDefault();
            client.IdClient = lastClient is null ? 0 : lastClient.IdClient + 1;

            Console.Clear();
            Clients.Add(client);
            Console.WriteLine($"Cliente adicionado! Seu código é: {client.IdClient}");

        }
    }
}
