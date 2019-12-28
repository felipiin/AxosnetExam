using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPIMVC.Models
{
    public class NewRecibo
    {
        public int IdRecibo { get; set; }
        public decimal Monto { get; set; }
        public string Fecha { get; set; }
        public string Comentario { get; set; }
        public int idMoneda { get; set; }
        public int idProveedor { get; set; }

    }
    public class ObjectRecibo : NewRecibo
    {
        public bool Activo { get; set; }
        public string Moneda { get; set; }
        public string Proveedor { get; set; }
    }
    public class ObjCombo
    {
        public int Id{ get; set; }
        public string Value{ get; set; }
    }
}
