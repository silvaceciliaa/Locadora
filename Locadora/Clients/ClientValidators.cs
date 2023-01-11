using System;
using locadora;

namespace Locadora.Clients
{
	public class ClientValidators
	{
        public void InputClientNameValidator(Client client)
        {
            client.Name = Console.ReadLine();

            while (client.Name == "")
            {
                Console.WriteLine("Campo obrigatório");
                Console.WriteLine("Nome: ");
                client.Name = Console.ReadLine();
            }
            client.Name = client.Name.First().ToString().ToUpper() + client.Name.Substring(1);

        }
    }
}

