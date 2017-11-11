using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiestaFutbolera.Models;
using System.ComponentModel.DataAnnotations;

namespace FiestaFutbolera.VistaModelo
{
    public class InformacionVM
    {
        //Modelos para las entidades
        public Usuarios Usuarios { get; set; }
        public Registrado Registrado { get; set; }

    }
}