using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPIMVC.Models
{
    public class Respuesta<T>
    {
        public int Estatus { get; set; }
        public string Mensaje { get; set; }
        public List<T> Datos { get; set; }
        public List<T> Error { get; set; }
    }
}