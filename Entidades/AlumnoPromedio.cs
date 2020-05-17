using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class AlumnoPromedio
    {
        private float promedio { get; set; }
        private string alumnoId { get; set; }

        private string alumnoNombre {get; set;}
        public AlumnoPromedio(string alumnoId,string alumnoNombre, float promedio)
        {
            this.alumnoId = alumnoId;
            this.alumnoNombre = alumnoNombre;
            this.promedio = promedio;
        }
    }
}