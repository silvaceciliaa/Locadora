using locadora;
MenuUser menuUsuario = new();
MenuAdmin menuAdmin = new();
UsersFunctions functions = new();
bool loopMenu = true;

while (loopMenu)
{
    Console.WriteLine("(1) Usuário (2) Admnistrador");
    var firstMenuOption = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (firstMenuOption)
    {
        case 1:
            menuUsuario.OpcaoMenuUsuario(functions);
            break;
        case 2:
            menuAdmin.Logged(functions);
            break;
        default:
            Console.WriteLine("Não entendi");
            break;
    }
}