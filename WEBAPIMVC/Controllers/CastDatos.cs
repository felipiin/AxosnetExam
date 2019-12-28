using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPIMVC.Models;
namespace WEBAPIMVC.Controllers
{
    public class CastDatos
    {
        static public ObjectRecibo ResultRecibo(Recibo recibo)
        {
            ObjectRecibo objectRecibo = new ObjectRecibo();

            objectRecibo.IdRecibo = recibo.idRecibo;
            objectRecibo.Monto = recibo.Monto;
            objectRecibo.Fecha = recibo.Fecha.ToShortDateString();
            objectRecibo.Comentario = recibo.Comentario;
            objectRecibo.Activo = recibo.Activo;
            objectRecibo.idMoneda = recibo.Moneda.idMoneda;
            objectRecibo.Moneda = recibo.Moneda.Moneda1;
            objectRecibo.idProveedor = recibo.Proveedor.idProveedor;
            objectRecibo.Proveedor = recibo.Proveedor.Proveedor1;

            return objectRecibo;
        }
        static public List<ObjectRecibo> ResultRecibo(List<Recibo> recibos)
        {
            List<ObjectRecibo> result = new List<ObjectRecibo>();

            foreach (var recibo in recibos)
            {
                ObjectRecibo objectRecibo = new ObjectRecibo();
                objectRecibo.IdRecibo = recibo.idRecibo;
                objectRecibo.Monto = recibo.Monto;
                objectRecibo.Fecha = recibo.Fecha.ToShortDateString();
                objectRecibo.Comentario = recibo.Comentario;
                objectRecibo.Activo = recibo.Activo;
                objectRecibo.idMoneda = recibo.Moneda.idMoneda;
                objectRecibo.Moneda = recibo.Moneda.Moneda1;
                objectRecibo.idProveedor = recibo.Proveedor.idProveedor;
                objectRecibo.Proveedor = recibo.Proveedor.Proveedor1;
                result.Add(objectRecibo);
            }
            return result;
        }

        static public List<ObjCombo> ResultCombo(List<Moneda> recibos)
        {
            List<ObjCombo> result = new List<ObjCombo>();

            foreach (var recibo in recibos)
            {
                ObjCombo objectcombo = new ObjCombo();
                objectcombo.Id = recibo.idMoneda;
                objectcombo.Value = recibo.Moneda1;
                result.Add(objectcombo);
            }
            return result;
        }
        static public List<ObjCombo> ResultCombo(List<Proveedor> recibos)
        {
            List<ObjCombo> result = new List<ObjCombo>();

            foreach (var recibo in recibos)
            {
                ObjCombo objectcombo = new ObjCombo();
                objectcombo.Id = recibo.idProveedor;
                objectcombo.Value = recibo.Proveedor1;
                result.Add(objectcombo);
            }
            return result;
        }
    }
}
    