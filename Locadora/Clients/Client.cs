using System;
namespace locadora
{
    public class Client
    {
        
        public int IdClient { get; set; }

        public string Name { get; set; }

        public int MoviesRented { get; set; }

        public double Debt { get; set; } = 0;

        public void ListOfClients()
        {
            Console.WriteLine($"ID: {IdClient}");
            Console.WriteLine($"Nome: {Name}");
            Console.WriteLine($"Quantidade a pagar: {Debt}");
            Console.WriteLine($"{MoviesRented} de 10 alugados");
            Console.WriteLine("\n");
        }
    }
}

