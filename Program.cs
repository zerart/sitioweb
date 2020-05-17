using System;
using CoreEscuela.Entidades;
using System.Collections.Generic;
using CoreEscuela.Util;
using System.Linq;
using CoreEscuela.App;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;

            EscuelaEngine engine = new EscuelaEngine();
            engine.Inicializar();
            //imprimirCursos(engine.escuela);
            Printer.WriteTitle("BIENVENIDOS A LAESCUELA");
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsg = reporteador.GetListaAsignaturas();
            var listaEvalAsig = reporteador.GetListaEvaPorAsi();
            var promxAsig = reporteador.GetListaPromedioAlumAsig();

            Printer.WriteTitle("CAPTURA DE UNA EVALUACIÓN POR CONSOLA");
            var newEval = new Evaluacion();
            string nombre, notaString;
            float nota;
            WriteLine("Ingrese el Nombre de la Evaluación");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El valor del nombre no puede ser vacio");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre fue ingresado correctamente");
            }
            WriteLine("Ingrese la nota de la Evaluación");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(notaString))
            {
                throw new ArgumentException("El valor del nota no puede ser vacio");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if (newEval.Nota > 5 || newEval.Nota < 0)
                    {
                        throw new ArgumentOutOfRangeException("La nota  debe estar entre 0 y 5");
                    }

                    WriteLine("La nota de la Evaluacion fue ingresado correctamente");
                }
                catch (ArgumentOutOfRangeException arge)
                {

                    WriteLine(arge.Message);
                }
                catch (Exception)
                {

                    WriteLine("La nota NO ES CORRECTA");
                }
                finally
                {

                }

            }

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Me salí");
        }

        private static void imprimirCursos(Escuela escuela)
        {
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            foreach (var curso in escuela.Cursos)
            {
                System.Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
            }
        }
    }
}
