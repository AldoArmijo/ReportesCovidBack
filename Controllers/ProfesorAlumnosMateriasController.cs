using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ReporteCOVID19Back.Models.ReporteCOVID19Modelos;


namespace ReporteCOVID19Back.Controllers
{
    [RoutePrefix("api/{token}")]
    public class ProfesorAlumnosMateriasController : ApiController
    {

        [HttpGet]
        [Route("getProfAlumnoMateria")]


        public ProfAlumnoMateriaModel GetProfAlumnoMateria(string IDSIUProfesor, string token)
        {
            ReportesCovid19 dbRC19 = new ReportesCovid19();

            COVID19Entities dbC19 = new COVID19Entities();

            ProfAlumnoMateriaModel res = new ProfAlumnoMateriaModel()
            {
                Payload = new List<Materia>(),
                    Result = false,
                    Message = ""
            };

            try
            {
                if (token == "reporteCOVID19")
                {

                    var infoSeleccionBloquados = dbC19.QPA_SeleccionBloqueados.Where(x => x.Docente_IDSIU == IDSIUProfesor && x.Activo == true).ToList();


                    var ClaveMaterias = infoSeleccionBloquados.Select(a => a.CveMateria).Distinct().ToList();

                    List<Materia> materiaAlumnos = new List<Materia>();

                    foreach(string cveMateria in ClaveMaterias)
                    {

                        List<Alumno> alumnos = infoSeleccionBloquados.Where(x => x.CveMateria == cveMateria).Select(x => new Alumno()
                        { 
                            IDSIU = x.Alumno_IDSIU,
                            Nombre = x.Alumno_Nombres,
                            Apellidos = x.Alumno_Apellidos,
                            NRC = x.NRC,
                            Campus = x.CAMPUS,
                            Telefono = x.Alumno_Telefono,
                            Correo = x.Alumno_O365,
                            FechaInicio = x.UltimaVisita,
                            FechaRegreso = x.FechaRegreso

                        }).ToList();

                        materiaAlumnos.Add(new Materia
                        {
                            CveMateria = cveMateria,
                            CveEscuela = infoSeleccionBloquados.Where(x => x.CveMateria == cveMateria).Select(x => x.Cve_Escuela).FirstOrDefault(),
                            NombreMateria = infoSeleccionBloquados.Where(x => x.CveMateria == cveMateria).Select(x => x.NombreMateria).FirstOrDefault(),
                            Alumnos = alumnos,

                        }) ;
                            
                    }


                    //List<string> claveEscuelas = infoPermiso.Select(x => x.Escuela).ToList();

                    //List<string> campus = infoPermiso.Select(x => x.Campus).ToList();

                    //List<Alumno> alumno = new List<Alumno>();



                    //List<Materia> listaAlumno = infoSeleccionBloquados.Select(x => new Materia()
                    //{
                    //    CveMateria = x.CveMateria,
                    //    NombreMateria = x.NombreMateria,
                    //    CveEscuela = x.Cve_Escuela,
                    //}).ToList();



                    //foreach(Alumno lista in infoSeleccionBloquados)
                    // {
                    //     alumno = lista;
                    // }

                    res.Payload = materiaAlumnos;
                    res.Result = true;
                    res.Message = "Obtener todos los alumnos que tiene cada materia del profesor.";


                }
                else
                {
                    res.Result = false;
                    res.Message = "El token no es válido o ya expiró";
                }

            }
            catch (Exception ex)
            {
                res.Result = false;
                res.Message = ex.Message;
            }
            finally
            {
                dbC19.Dispose();
            }

            return res;


        }

        [HttpGet]
        [Route("getEscuelaMaterias")]


        public EscuelaMateriasaModel GetEscuelaMaterias(string Cve_Escuela, string token)
        {
            ReportesCovid19 dbRC19 = new ReportesCovid19();

            COVID19Entities dbC19 = new COVID19Entities();

            EscuelaMateriasaModel res = new EscuelaMateriasaModel()
            {
                Payload = new List<Materia>(),
                Result = false,
                Message = ""
            };

            try
            {
                if (token == "reporteCOVID19")
                {

                    var infoSeleccionBloquados = dbC19.QPA_SeleccionBloqueados.Where(x => x.Cve_Escuela == Cve_Escuela && x.Activo == true).ToList();


                    var ClaveMaterias = infoSeleccionBloquados.OrderBy(x => x.CveMateria).Select(a => a.CveMateria).Distinct().ToList();

                    List<Materia> materiaAlumnos = new List<Materia>();

                    foreach (string cveMateria in ClaveMaterias)
                    {

                        List<Alumno> alumnos = infoSeleccionBloquados.Where(x => x.CveMateria == cveMateria).Select(x => new Alumno()
                        {
                            IDSIU = x.Alumno_IDSIU,
                            Nombre = x.Alumno_Nombres,
                            Apellidos = x.Alumno_Apellidos,
                            NRC = x.NRC,
                            Campus = x.CAMPUS,
                            Telefono = x.Alumno_Telefono,
                            Correo = x.Alumno_O365,
                            FechaInicio = x.UltimaVisita,
                            FechaRegreso = x.FechaRegreso

                        }).ToList();

                        materiaAlumnos.Add(new Materia
                        {
                            CveMateria = cveMateria,
                            CveEscuela = infoSeleccionBloquados.Where(x => x.CveMateria == cveMateria).Select(x => x.Cve_Escuela).FirstOrDefault(),
                            NombreMateria = infoSeleccionBloquados.Where(x => x.CveMateria == cveMateria).Select(x => x.NombreMateria).FirstOrDefault(),
                            Alumnos = alumnos,

                        });

                    }



                    res.Payload = materiaAlumnos;
                    res.Result = true;
                    res.Message = "Obtener todos los alumnos que tiene cada materia del profesor.";


                }
                else
                {
                    res.Result = false;
                    res.Message = "El token no es válido o ya expiró";
                }

            }
            catch (Exception ex)
            {
                res.Result = false;
                res.Message = ex.Message;
            }
            finally
            {
                dbC19.Dispose();
            }

            return res;


        }

    }



}


