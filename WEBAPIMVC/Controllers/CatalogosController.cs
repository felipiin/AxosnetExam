using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace WEBAPIMVC.Controllers
{
    public class CatalogosController : ApiController
    {
        // GET: api/Catalogos
        public string GetMoneda()
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                List<Models.Moneda> moneda = db.Moneda.Where(x => x.Activo == true).ToList();
                Models.Respuesta<Models.Moneda> respuesta = new Models.Respuesta<Models.Moneda>();
                respuesta.Estatus = 200;
                respuesta.Mensaje = "OK";
                respuesta.Datos = moneda;
                return JsonConvert.SerializeObject(respuesta);
            }
        }
        public List<Models.Proveedor> GetProveedor()
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                return db.Proveedor.Where(x => x.Activo == true).ToList();
            }
        }
        public void PutMoneda(Models.Moneda nuevo)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {

                db.Moneda.Add(nuevo);
                db.SaveChanges();
            }
        }
        public void PutProveedor(Models.Proveedor nuevo)
        {
            using (Models.ExamenEntities db = new Models.ExamenEntities())
            {
                db.Proveedor.Add(nuevo);
                db.SaveChanges();
            }
        }
    }
}