using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FiestaFutbolera.Models
{
    public class Registrado
    {
        public long NroIdUsuario { get; set; }
        public string TipoIdUsuario { get; set; }
        public byte[] Foto { get; set; }
        [Required(ErrorMessage="La dirección de correo es requerida")]
        public string DirCorreo { get; set; }
        public string Password { get; set; }

    }
}