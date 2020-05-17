using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase, Ilugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento...");
            
            Console.WriteLine($"Curos {Nombre} Limpio");
        }
    }
}