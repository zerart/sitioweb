using System.Collections.Generic;
using System;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, Ilugar
    {
        public int AñoDeCreación { get; set; }
        public string País { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela tipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);
        public Escuela(string nombre, int año, TiposEscuela tipos,
                        string pais = "", string ciudad = "")
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            País = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {tipoEscuela} {System.Environment.NewLine} País: {País}, Ciudad: {Ciudad}";
        }
        public string Direccion { get; set; }
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");

            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }

            Console.WriteLine($"Escuela {Nombre} Limpio");
        }

    }
}