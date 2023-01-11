using System;
using locadora;

namespace Locadora.Clients
{
    public class ClientsFunctions
    {
        public List<Client> Clients { get; set; }

        public ClientsFunctions()
        {

            Clients = new List<Client>();

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

        public void FindClient()
        {
            Console.WriteLine("Digite seu código: ");
            int codigoCliente = int.Parse(Console.ReadLine());
            Console.Clear();
            var codigoClienteDigitado = Clients.Where(x => x.IdClient == codigoCliente);
        }
    }
}

