using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.Write("======== Hello, Word! Sin salto de línea ========");

        // Este es un comentario en C#

        string str1 = "             >  .- \" -.   .-\\               ";
        string str2 = "             ``--._`-...-'\"                ";

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine(".-.                                        ");
        Console.WriteLine(@"|  \                                    __ ");
        Console.WriteLine(@"(   `\                                 /  |");
        Console.WriteLine(@" \    \                               /   |");
        Console.WriteLine(@"  |  | `\                            /    /");
        Console.WriteLine(@"  |  |\  \                         /` /  / ");
        Console.WriteLine(@"  |  | \  \                     ./ '  /  / ");
        Console.WriteLine(@"  |  |  \  \                   / _ /|  |   ");
        Console.WriteLine(@"  |  |   \  \                / '  _/  |  | ");
        Console.WriteLine(@"  |  |    \  \             / '   /   /   ) ");
        Console.WriteLine(@"  | (      \  \           /    /   /   /   ");
        Console.WriteLine(@"  (   \     \  \         /    /   /   /    ");
        Console.WriteLine(@"   \   \     )  )       /    /   /   /     ");
        Console.WriteLine(@"    \   \    |  |      /    /   /   /      ");
        Console.WriteLine(@"     \   \   |  |     /    /   /   /       ");
        Console.WriteLine(@"      \   \  |  |    /    /   /   /        ");
        Console.WriteLine(@"       \   \ |  | (    /   /  / '          ");
        Console.WriteLine(@"        \   \|  |   |   /  / ' /'          ");
        Console.WriteLine(@"         \   \  /`. |`. \/ ' /'            ");
        Console.WriteLine(@"          \     `-; -; -;   / '            ");
        Console.WriteLine(@"           `\            <                 ");
        Console.WriteLine(str1);
        Console.WriteLine(@"            / .' ,__   `   \               ");
        Console.WriteLine(@"           |     |  \      /\              ");
        Console.WriteLine(@"           |     | __ \    | _ \           ");
        Console.WriteLine(@"      _.------.._ | o\ |   | o`|\_         ");
        Console.WriteLine("   ,-`.          `. | |   |  | ''`'-._._   ");
        Console.WriteLine("  _.- '.            `:_|.__|/`'.-- - ; _ ` ");
        Console.WriteLine(@" '   '     ``--.```--.. \/`..--'''  ; `-.  ");
        Console.WriteLine("  .-``.      -.,-..__._.._._.__.   ;`-.    ");
        Console.WriteLine(" '    `.        `;   |  | |      .'    `   ");
        Console.WriteLine("       `.         `-.|  | | _'             ");
        Console.WriteLine("         `.._.  `--''`_.- '                ");
        Console.WriteLine(str2);
        Console.WriteLine("        jgs      ;:    ;");


        String numStr = "";
        int num = -1;
        bool esValorValido = true;

        while (numStr != "0" || (num > 7 && num <= 1) || esValorValido == false)
        {
            Console.WriteLine("\nIntroduce un número del 1 al 7 (0 para salir): ");

            numStr = Console.ReadLine();

            string msj = "";

            if ((String.IsNullOrEmpty(numStr.Trim()) || !int.TryParse(numStr, out num)))
            {
                msj = "Solo puede introducir números del 0 al 7";
                esValorValido = false;
            }
            else if (num == 0)
            {
                msj = "¡Hasta luego!";
                break;
            }
            else
            {
                esValorValido = true;
                switch (num)
                {
                    case 1:
                        msj = "Lunes";
                        break;
                    case 2:
                        msj = "Martes";
                        break;
                    case 3:
                        msj = "Miércoles";
                        break;
                    case 4:
                        msj = "Jueves";
                        break;
                    case 5:
                        msj = "Viernes";
                        break;
                    case 6:
                        msj = "Sábado";
                        break;
                    case 7:
                        msj = "Domingo";
                        break;
                    default:
                        msj = "Valor no válido, intenta de nuevo.";
                        break;
                }
            }              
            Console.WriteLine(msj);
        }
    }
}