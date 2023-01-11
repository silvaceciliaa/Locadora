using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int TotalQuantity { get; set; }

        public int QuantityAvailable { get; set; }

        public DateTime ReleaseYear { get; set; }

        public string Client { get; set; }

        public double Fee { get; set; } = 5.00;

        public void Catalog()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Title}");
            Console.WriteLine($"Diretor: {Director}");
            Console.WriteLine($"Ano de Lançamento: {ReleaseYear.ToString("yyyy")}");
            Console.WriteLine($"{QuantityAvailable} de {TotalQuantity} para alugar ");
            Console.WriteLine($"Aluguel: {Fee}");
            Console.WriteLine("\n");
        }
    }
}