using System;
using locadora;

namespace Locadora.Movies
{
	public class MovieValidators
	{
        public void InputTitleValidator(Movie movie)
        {
            while (movie.Title == "")
            {
                Console.WriteLine("Campo obrigatório");
                Console.WriteLine("Título: ");
                movie.Title = Console.ReadLine();
            }
            movie.Title = movie.Title.First().ToString().ToUpper() + movie.Title.Substring(1);
        }
        public void InputDirectorValidator(Movie movie)
        {
            if (movie.Director == "")
            {
                movie.Director = "Desconhecido";
            }
            else
            {
                movie.Director = movie.Director.First().ToString().ToUpper() + movie.Director.Substring(1);
            }
        }
        public void InputReleaseYearValidator(Movie movie)
        {
            var date = Console.ReadLine();
            var convert = DateTime.TryParse(date, out var result);

            if (!convert)
            {
                movie.ReleaseYear = DateTime.Today;
                movie.Fee = 3.50 + movie.Fee;
            }
            else
            {
                convert = DateTime.TryParse(date, out result);
                movie.ReleaseYear = result;
            }
        }
        public void InputQuantityValidator(Movie movie)
        {
            var quantity = Console.ReadLine();
            var convertionSuccessful = int.TryParse(quantity, out var result);

            if (!convertionSuccessful)
            {
                movie.TotalQuantity = 1;
                movie.QuantityAvailable = movie.TotalQuantity;
                movie.Fee = 1.00 + movie.Fee;
            }
            else
            {
                convertionSuccessful = int.TryParse(quantity, out result);
                movie.TotalQuantity = result;
                movie.QuantityAvailable = result;
            }
        }
    }
}

