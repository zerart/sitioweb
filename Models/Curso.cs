using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public string EscuelaId { get; set; }

        public Escuela Escuela { get; set; }
        [Display(Prompt="Dirección correspondencia", Name="Address")]
        [Required(ErrorMessage = "Se requiere la dirección")]
        [MinLength(10, ErrorMessage="La longitud mínima es 10")]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(5)]
        public override string Nombre { get; set; }
    }
}