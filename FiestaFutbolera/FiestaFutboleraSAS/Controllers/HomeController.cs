using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiestaFutbolera.Models;
using FiestaFutbolera.VistaModelo;

namespace FiestaFutbolera.Controllers
{
    public class HomeController : Controller
    {
        private String MensajeEmergente;

        public ActionResult Index()
        {//Invoca la pagina principal
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult RegistroUsuario()
        {//Invoca vista de registro de usuario
            return View();
        }
        
        public ActionResult Ingreso(InformacionVM iVM)
        {//Invoca el ingreso de un usuario registrado
            return View("IngresoOK");
        }

        [HttpPost]
        public ActionResult ContactoEmail()
        {//Invoca el envio de correo para el dueño
            return View();
        }

        [HttpPost]
        public ActionResult CrearUsuarioRegistrado(InformacionVM iVM)
        {//Se usa para registrar un usuario se crea registro 
         //en las entidades Usuarios y Registrado

            try
            {
                UsuariosServicioCliente USC = new UsuariosServicioCliente();
                //Se completa la información faltante del Usuario a Registrar
                iVM.Registrado.NroIdUsuario = iVM.Usuarios.NroIdUsuario;
                iVM.Registrado.TipoIdUsuario = iVM.Usuarios.TipoIdUsuario;

                //Alta en entidad Usuarios y Registrados
                bool respuesta = USC.CrearUsuario(iVM.Usuarios);
                if (respuesta)
                {
                    respuesta = USC.CrearUsuarioRegistrado(iVM.Registrado);
                }

                //Vamos a pagina de ingreso
                TempData["testmsg"] = "<script>alert('Jugador Registrado Exitosamente');</script>";
                return RedirectToAction("Ingreso");
            }
            catch (Exception)
            {
                //Vamos a pagina de inicio
                TempData["testmsg"] = "<script>alert('Error Inesperado');</script>";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public void ActualizarUsuarioRegistrado(InformacionVM iVM)
        {//Se usa para actualizar un usuario
            UsuariosServicioCliente USC = new UsuariosServicioCliente();
            bool respuesta = USC.ActualizarUsuarioRegistrado(iVM.Registrado);
            TempData["testmsg"] = "<script>alert('Usuario actualizado Correctamente');</script>";
        
        }

        public ActionResult EliminarUsuarioRegistrado(InformacionVM iVM)
        {//Se usa para eliminar un usuario
            UsuariosServicioCliente USC = new UsuariosServicioCliente();
            bool respuesta = USC.EliminarUsuarioRegistrado(iVM.Registrado);
            TempData["testmsg"] = "<script>alert('Usuario Dado de Baja Correctamente');</script>";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BuscarUsuarioRegistrado(InformacionVM iVM)
        {//Se usa para eliminar un usuario
            UsuariosServicioCliente USC = new UsuariosServicioCliente();
            Registrado respuesta = USC.BuscarUsuarioRegistrado(iVM.Registrado.DirCorreo);
            if (respuesta != null)
            {
                if (respuesta.DirCorreo == iVM.Registrado.DirCorreo)
                {
                    if (respuesta.Password == iVM.Registrado.Password)
                    {
                        //Vamos a pagina de ingreso
                        TempData["testmsg"] = "<script>alert('Ingreso Exitosamente');</script>";
                        return RedirectToAction("Ingreso");
                    }
                    else
                    {
                        TempData["testmsg"] = "<script>alert('Clave Incorrecta');</script>";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    //Nos quedamos en la pagina actual
                    TempData["testmsg"] = "<script>alert('Jugador No Registrado');</script>";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //Nos quedamos en la pagina actual
                TempData["testmsg"] = "<script>alert('Jugador No Registrado');</script>";
                return RedirectToAction("Index");
            }
        }

    }
}
