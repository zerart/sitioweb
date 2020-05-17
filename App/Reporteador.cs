using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq;

namespace CoreEscuela
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (dicObsEsc == null)
            {
                throw new ArgumentException(nameof(dicObsEsc));
            }
            else
            {
                _diccionario = dicObsEsc;
            }

        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            IEnumerable<Evaluacion> rta;
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Evaluacion>();
            }
            else
            {
                rta = new List<Evaluacion>();
            }
            return rta;
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones);

        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();
            return (from eval in listaEvaluaciones
                    select eval.Asignatura.Nombre).Distinct();

        }

        //Lista de evaluaciones por asignatura
        public Dictionary<string, IEnumerable<Evaluacion>> GetListaEvaPorAsi()
        {
            var diccRpta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var liAsignatura = GetListaAsignaturas(out var listaEvaluaciones);

            foreach (var asi in liAsignatura)
            {
                var evalsAsignatura = from eva in listaEvaluaciones
                                      where eva.Asignatura.Nombre == asi
                                      select eva;
                diccRpta.Add(asi, evalsAsignatura);
            }

            return diccRpta;
        }
        //Asignatura alumno con promedio
        public Dictionary<string, IEnumerable<object>> GetListaPromedioAlumAsig()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();

            var diccRpta = GetListaEvaPorAsi();

            foreach (var asi in diccRpta)
            {
                var dummy = from eval in asi.Value
                            group eval by new
                            {
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }
                            into grupoEvalsAlumno
                            select new
                            AlumnoPromedio(
                                grupoEvalsAlumno.Key.UniqueId, grupoEvalsAlumno.Key.Nombre,
                                grupoEvalsAlumno.Average(Evaluacion => Evaluacion.Nota)
                                );

                rta.Add(asi.Key, dummy);
            }

            return rta;
        }

    }
}