using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WEBAPIMVC.Models;
namespace WEBAPIMVC.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        [Route("Recibos")]
        public Respuesta<ObjectRecibo> GetRecibos()
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {

                List<Recibo> recibo = db.Recibo.Where(x => x.Activo == true).ToList();

                Models.Respuesta<Models.ObjectRecibo> respuesta = new Models.Respuesta<Models.ObjectRecibo>();
                respuesta.Estatus = 200;
                respuesta.Mensaje = "OK";
                respuesta.Datos = CastDatos.ResultRecibo(recibo);
                return respuesta;//JsonConvert.SerializeObject(respuesta);
            }
        }

        // GET api/values/5
        [HttpGet]
        [Route("Recibo/{id}")]
        public Respuesta<ObjectRecibo>  GetREcibo(int id)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                //Models.ExamenEntities db = new Models.ExamenEntities();
                List<Recibo> recibo = db.Recibo.Where(x => x.Activo == true && x.idRecibo == id).ToList();
                Models.Respuesta<Models.ObjectRecibo> respuesta = new Models.Respuesta<Models.ObjectRecibo>();
                respuesta.Estatus = 200;
                respuesta.Mensaje = "OK";
                respuesta.Datos = CastDatos.ResultRecibo(recibo);
                return respuesta;
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut]
        [Route("Recibo/Agregar")]
        public Respuesta<ObjCombo> Put(Models.NewRecibo nuevo)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                Models.Respuesta<Models.ObjCombo> respuesta = new Models.Respuesta<Models.ObjCombo>();

                Recibo recibo;
                if (nuevo.IdRecibo > 0)
                {
                    recibo = db.Recibo.Where(x => x.idRecibo == nuevo.IdRecibo).First();
                    recibo.Update(nuevo);
                }
                else 
                {
                    recibo = new Recibo(nuevo);
                    db.Recibo.Add(recibo);
                }
                recibo.Moneda = db.Moneda.Where(x => x.idMoneda == nuevo.idMoneda).FirstOrDefault();
                recibo.Proveedor = db.Proveedor.Where(x => x.idProveedor == nuevo.idProveedor).FirstOrDefault();

                db.SaveChanges();
                respuesta.Estatus = 200;
                respuesta.Mensaje = "OK";
                return respuesta;
            }


        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("Recibo/Eliminar/{id}")]
        public Respuesta<ObjCombo> PUTEliminaRecibo(int id)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                Models.Respuesta<Models.ObjCombo> respuesta = new Models.Respuesta<Models.ObjCombo>();
                Models.Recibo recibo = db.Recibo.Where(x => x.idRecibo == id).First();
                recibo.Activo = false;
                db.SaveChanges();
                respuesta.Estatus = 200;
                respuesta.Mensaje = "OK";
                return respuesta;
            }
        }


        ////////////////////////////////////////
        ///MONEDA
        [HttpGet]
        [Route("Monedas")]
        public Respuesta<ObjCombo> GetMoneda()
        {
            Models.ExamenEntities db = new Models.ExamenEntities();
            List<Moneda> moneda = db.Moneda.Where(x => x.Activo == true).ToList();
            Models.Respuesta<Models.ObjCombo> respuesta = new Models.Respuesta<Models.ObjCombo>();
            respuesta.Estatus = 200;
            respuesta.Mensaje = "OK";
            respuesta.Datos = CastDatos.ResultCombo(moneda);
            return respuesta;
        }


        ////////////////////////////////////////
        ///PROVEEDOR
        [HttpGet]
        [Route("Proveedores")]
        public Respuesta<ObjCombo> Proveedor()
        {
            Models.ExamenEntities db = new Models.ExamenEntities();
            List<Proveedor> proveedor = db.Proveedor.Where(x => x.Activo == true).ToList();
            Models.Respuesta<Models.ObjCombo> respuesta = new Models.Respuesta<Models.ObjCombo>();
            respuesta.Estatus = 200;
            respuesta.Mensaje = "OK";
            respuesta.Datos = CastDatos.ResultCombo(proveedor);
            return respuesta;
        }

    }
}
