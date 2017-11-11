using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiestaFutbolera.Models
{
    public class Usuarios
    {
        public long Telefono { get; set; }
        public string Nombre { get; set; }
        public long NroIdUsuario { get; set; }
        public string TipoIdUsuario { get; set; }
    }
}