using static System.Console;

namespace CoreEscuela.Util
{

    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            System.Console.WriteLine("".PadLeft(tam, '='));
        }
        public static void WriteTitle(string titulo)
        {

            DrawLine(titulo.Length+4);
            WriteLine($"| {titulo} |");    
            DrawLine(titulo.Length+4);
        }
        public static void PresioneEnter()
        {
           WriteLine("Presione ENTER para continuar");
        }
    }
}