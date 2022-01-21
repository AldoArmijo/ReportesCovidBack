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
    public class RolesController : ApiController
    {
        //Roles
        [HttpGet]
        [Route("getRoles")]

        public InfoRolesModel GetRoles(string IDSIU, string token)
        {
            ReportesCovid19 db = new ReportesCovid19();

            InfoRolesModel res = new InfoRolesModel()
            {
                Payload = new List<QCat_Programas>(),
                Result = false,
                Message = ""
            };

            try 
            {
                if(token == "reporteCOVID19")
                {

                   var existeIDSIU = db.Permisos.FirstOrDefault(x => x.IDSIU == IDSIU && x.Activo == true);


                   var infoPermiso = db.Permisos.Where(x => x.IDSIU == IDSIU && x.Activo == true).ToList();



                    List<string> claveEscuelas = infoPermiso.Select(x => x.Escuela).ToList();

                    List<string> campus = infoPermiso.Select(x => x.Campus).ToList();


                    //for (int i=0; i<infoPermiso.Count(); i++)
                    //{
                    //    claveEscuelas.Add(infoPermiso[i].Escuela);
                    //    campus.Add(infoPermiso[i].Campus);
                    //}




                    long Rol;

                    if(existeIDSIU == null)
                    {
                        Rol = 4;
                    } else
                    {
                        Rol = existeIDSIU.Rol;
                    }


                    switch (Rol)
                    {
                        case 1:
                            break;

                        case 2:

                            res.Payload = db.QCat_Programas.Where(c => claveEscuelas.Contains((string)c.Clave_escuela) && campus.Contains((string)c.Campus) && c.Activo == true).OrderBy(x => x.Clave_escuela).ThenBy(y => y.Campus).ToList();
                            res.Result = true;
                            res.Message = "Si encuentra la informacion de las programas.";
                            break;

                        case 3:
                            break;

                        case 4:

                            break;

                    }




                } else
                {
                    res.Result = false;
                    res.Message = "El token no es válido o ya expiró";
                }

            } catch (Exception ex)
            {
                res.Result = false;
                res.Message = ex.Message;
            }
            finally
            {
                db.Dispose();
            }

            return res;

        }




    }
}
