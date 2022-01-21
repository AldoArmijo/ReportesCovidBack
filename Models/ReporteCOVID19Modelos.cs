using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReporteCOVID19Back.Models
{
    public class ReporteCOVID19Modelos : ApiController
    {

        public class InfoRolesModel
        {
            public List<QCat_Programas> Payload { get; set; }
            public bool Result { get; set; }
            public string Message { get; set; }
        }



        public class ProfAlumnoMateriaModel
        {
            public List<Materia> Payload { get; set; }
            public bool Result { get; set; }
            public string Message { get; set; }
        }

        public class Materia
        {
            public string CveMateria { get; set; }
            public string NombreMateria  { get; set; }
            public string CveEscuela { get; set; }

            public List<Alumno> Alumnos { get; set; }

        }

        public class Alumno
        {
            public string IDSIU { get; set; }
            public int? NRC { get; set; }
            public string Campus { get; set; }

            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }

            public Nullable<System.DateTime> FechaInicio { get; set; }
            public Nullable<System.DateTime> FechaRegreso { get; set; }

        }


        public class EscuelaMateriasaModel
        {
            public List<Materia> Payload { get; set; }
            public bool Result { get; set; }
            public string Message { get; set; }
        }



    }
}