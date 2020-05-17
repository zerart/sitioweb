using System;

namespace CoreEscuela
{
    class Escuela
    {
        public string nombre;
        public string direccion;
        public int añoFundacion;

        public void Timbre()
        {
            //Todo

            Console.Beep(2000,2000);
        }

        public string ceo = "Freddy";
        

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Escuela escuela1 = new Escuela();
            escuela1.nombre = "Paltzi";
            escuela1.direccion = "Calle los 70";
            escuela1.añoFundacion = 1987;
            Console.WriteLine("TIMBRE");
            escuela1.Timbre();
            Console.WriteLine(escuela1.nombre + " " + escuela1.direccion);
            
        }
    }
}
