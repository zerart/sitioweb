using System;
using System.Collections.Generic;

namespace asp.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; }

        public string CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}