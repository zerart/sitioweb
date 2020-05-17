using CoreEscuela.Entidades;
using CoreEscuela.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreEscuela.App
{

    public sealed class EscuelaEngine
    {
        public Escuela escuela { get; set; }

        public EscuelaEngine()
        {


        }
        public void Inicializar()
        {
            escuela = new Escuela("Platzi Academy", 2018, TiposEscuela.Secundaria,
                                    pais: "Colombia", ciudad: "Medellin");
            CargarCursos();
            CargarAsiganaturas();

            CargarEvaluaciones();

        }


        private List<Alumno> GenerarAlumnosalAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipe", "Juancho" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe" };
            string[] nombre2 = { "Andriele", "Livia", "Rick" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            foreach (var item in listaAlumnos)
            {
                item.Evaluaciones = new List<Evaluacion>();
                
            }


            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();

        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, bool imprEval = false)
        {
            foreach (var obj in dic)
            {

                Printer.WriteTitle(obj.Key.ToString());
                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (imprEval)
                            {
                                Console.WriteLine(val);
                            }
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine("Escuela: " + val);
                            break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine("Alumno: " + val.Nombre);
                            break;
                        case LlaveDiccionario.Curso:
                            var curtmp = val as Curso;
                            int count = 0;
                            if (val != null)
                            {
                                count = curtmp.Alumnos.Count();
                                Console.WriteLine("Curso: " + val.Nombre + " Cantidad Alumnos: " + count.ToString());
                            }

                            break;

                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {

            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] { escuela });
            diccionario.Add(LlaveDiccionario.Curso, escuela.Cursos);
            var listatmp = new List<Evaluacion>();
            var listatmp2 = new List<Asignatura>();
            var listatmp3 = new List<Alumno>();
            foreach (var cur in escuela.Cursos)
            {
                listatmp2.AddRange(cur.Asignaturas);
                listatmp3.AddRange(cur.Alumnos);
                foreach (var alu in cur.Alumnos)
                {
                    listatmp.AddRange(alu.Evaluaciones);
                }
            }
            diccionario.Add(LlaveDiccionario.Evaluacion, listatmp);
            diccionario.Add(LlaveDiccionario.Asignatura, listatmp2);
            diccionario.Add(LlaveDiccionario.Alumno, listatmp3);
            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignatura,
            out int conteoAlumnos,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeEvaluaciones = true,
            bool traeCursos = true)
        {
            conteoEvaluaciones = 0;
            conteoCursos = 0;
            conteoAsignatura = 0;
            conteoAlumnos = 0;
            var listObj = new List<ObjetoEscuelaBase>();
            listObj.Add(escuela);

            if (traeCursos)
            {
                listObj.AddRange(escuela.Cursos);
                conteoCursos = escuela.Cursos.Count();
            }

            foreach (var curso in escuela.Cursos)
            {
                conteoAsignatura += curso.Asignaturas.Count();
                conteoAlumnos += curso.Alumnos.Count();
                if (traeAsignaturas)
                {
                    listObj.AddRange(curso.Asignaturas);
                }
                if (traeAsignaturas)
                {
                    listObj.AddRange(curso.Alumnos);
                }
                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count();
                    }
                }
            }
            return listObj.AsReadOnly();
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeEvaluaciones = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuelaBases(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
           out int conteoEvaluaciones,
           out int conteoCursos,
           out int conteoAsignatura,
           bool traeAlumnos = true,
           bool traeAsignaturas = true,
           bool traeEvaluaciones = true,
           bool traeCursos = true)
        {
            return GetObjetoEscuelaBases(out conteoEvaluaciones, out conteoCursos, out conteoAsignatura, out int dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeEvaluaciones = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuelaBases(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        private void CargarEvaluaciones()
        {
            var rnd = new Random();
            foreach (var curso in escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {

                    foreach (var alumno in curso.Alumnos)
                    {                        
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)Math.Round(5.00 * rnd.NextDouble(), 2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarCursos()
        {
            escuela.Cursos = new List<Curso>(){
                new Curso() {Nombre="101",Jornada=TiposJornada.Mañana},
                new Curso() {Nombre="201",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="301",Jornada=TiposJornada.Mañana},
                new Curso() {Nombre="302",Jornada=TiposJornada.Tarde},
                new Curso() {Nombre="402",Jornada=TiposJornada.Tarde},
                new Curso{Nombre="502",Jornada=TiposJornada.Tarde}
            };
            Random rnd = new Random();

            foreach (var curso in escuela.Cursos)
            {
                curso.Alumnos = GenerarAlumnosalAzar(rnd.Next(2, 6));
            }
        }

        private void CargarAsiganaturas()
        {
            foreach (var curso in escuela.Cursos)
            {
                List<Asignatura> listaAsignatura = new List<Asignatura>()
                {
                    new Asignatura {Nombre="Matemáticas"},
                    new Asignatura{Nombre="Educación física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura() {Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignatura;
            }
        }
    }
}