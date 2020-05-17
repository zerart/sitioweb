using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace asp.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuela { get; set; }

        public DbSet<Asignatura> Asignatura { get; set; }

        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Curso> Curso { get; set; }

        public DbSet<Evaluación> Evaluación { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2020;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzy School";
            escuela.Pais = "Perú";
            escuela.Ciudad = "Lima";
            escuela.Dirección = "Av. Brasil 4203";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            //Cargar cursos de la escuela

            var cursos = CargarCursos(escuela);

            //x Cada Curso Cargar Asignaturas

            var asignaturas = CargarAsignaturas(cursos);

            //x cada Curso Cargar Alumnos 
            var alumnos = CargarAlumnos(cursos);
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
        }


        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();
            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmpList = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmpList);
            }
            return listaAlumnos;
        }
        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>();
            foreach (var cu in cursos)
            {
                var tmpList = new List<Asignatura>
                {
                    new Asignatura
                    {
                        Nombre = "Matemáticas",
                        CursoId = cu.Id,
                        Id = Guid.NewGuid().ToString()
                    },
                    new Asignatura
                    {
                        Nombre = "Física",
                        CursoId = cu.Id,
                        Id = Guid.NewGuid().ToString()
                    },
                    new Asignatura
                    {
                        Nombre = "Inglés",
                        CursoId = cu.Id,
                        Id = Guid.NewGuid().ToString()
                    },
                    new Asignatura
                    {
                        Nombre = "Programación",
                        CursoId = cu.Id,
                        Id = Guid.NewGuid().ToString()
                    }
                };
                listaCompleta.AddRange(tmpList);
            }
            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso()
                {
                    Id= Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre="101",
                    Jornada = TiposJornada.Mañana,
                    Dirección="Mi casa"
                },
                new Curso() 
                {
                    Id= Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id, 
                    Nombre="201", Jornada = TiposJornada.Tarde,
                    Dirección="Mi casa"
                },
                new Curso() 
                {
                    Id= Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre="301", 
                    Jornada = TiposJornada.Mañana,
                    Dirección="Mi casa"
                },
                new Curso() 
                {
                    Id= Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id, 
                    Nombre="401", 
                    Jornada = TiposJornada.Noche,
                    Dirección="Mi casa"
                }
            };

        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {

            string[] nombre1 = { "Alba", "Felipe", "Juancho" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe" };
            string[] nombre2 = { "Andriele", "Livia", "Rick" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoId = curso.Id,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();


        }
    }
}