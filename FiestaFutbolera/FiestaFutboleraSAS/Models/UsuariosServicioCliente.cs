using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace FiestaFutbolera.Models
{
    public class UsuariosServicioCliente
    {
        //Local - DB nube
        //private string URL_WCFUsuarios = "http://localhost:54911/CRUDUsuarios.svc/";
        //nube - DB nube
        private string URL_WCFUsuarios = "http://wcfcrudusuarios.azurewebsites.net/CRUDUsuarios.svc/";

        /*
         * Métodos para usuarios registrados
         */
        public bool CrearUsuarioRegistrado(Registrado DatosCrearR)
        {
            try
            {
                DataContractJsonSerializer objMenoriaFisica = new DataContractJsonSerializer(typeof (Registrado));
                MemoryStream objDatosSerializar = new MemoryStream();
                objMenoriaFisica.WriteObject(objDatosSerializar,DatosCrearR);
                string data = Encoding.UTF8.GetString(objDatosSerializar.ToArray(), 0, (int)objDatosSerializar.Length);
                var ClienteWeb = new WebClient();
                ClienteWeb.Headers["Content-type"] = "application/json";
                ClienteWeb.Encoding = Encoding.UTF8;
                ClienteWeb.UploadString(URL_WCFUsuarios + "CrearUsuarioRegistrado", "POST",data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Registrado BuscarUsuarioRegistrado(string Correo)
        {
            Registrado DatosServer = new Registrado();
            try
            {
                var ClienteWeb = new WebClient();
                String url = string.Format(URL_WCFUsuarios + "BuscarUsuarioRegistrado/{0}", Correo);
                var JSON = ClienteWeb.DownloadString(url);
                var jsUsuarios = new JavaScriptSerializer();
                DatosServer = jsUsuarios.Deserialize<Registrado>(JSON);
                return DatosServer;
            }
            catch (Exception)
            {
                return null;   
            }
        }

        public bool ActualizarUsuarioRegistrado(Registrado DatosActualizarR)
        {
            try
            {
                DataContractJsonSerializer objMenoriaFisica = new DataContractJsonSerializer(typeof(Registrado));
                MemoryStream objDatosSerializar = new MemoryStream();
                objMenoriaFisica.WriteObject(objDatosSerializar, DatosActualizarR);
                string data = Encoding.UTF8.GetString(objDatosSerializar.ToArray(), 0, (int)objDatosSerializar.Length);
                var ClienteWeb = new WebClient();
                ClienteWeb.Headers["Content-type"] = "application/json";
                ClienteWeb.Encoding = Encoding.UTF8;
                ClienteWeb.UploadString(URL_WCFUsuarios + "ActualizarUsuarioRegistrado", "PUT", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarUsuarioRegistrado(Registrado DatosBorrar)
        {
            try
            {
                DataContractJsonSerializer objMenoriaFisica = new DataContractJsonSerializer(typeof(Registrado));
                MemoryStream objDatosSerializar = new MemoryStream();
                objMenoriaFisica.WriteObject(objDatosSerializar, DatosBorrar);
                string data = Encoding.UTF8.GetString(objDatosSerializar.ToArray(), 0, (int)objDatosSerializar.Length);
                var ClienteWeb = new WebClient();
                ClienteWeb.Headers["Content-type"] = "application/json";
                ClienteWeb.Encoding = Encoding.UTF8;
                ClienteWeb.UploadString(URL_WCFUsuarios + "EliminarUsuarioRegistrado", "DELETE",data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*
         * Métodos para usuarios NO registrados
         */
        public bool CrearUsuario(Usuarios DatosCrear)
        {
            try
            {
                DataContractJsonSerializer objMenoriaFisica = new DataContractJsonSerializer(typeof(Usuarios));
                MemoryStream objDatosSerializar = new MemoryStream();
                objMenoriaFisica.WriteObject(objDatosSerializar, DatosCrear);
                string data = Encoding.UTF8.GetString(objDatosSerializar.ToArray(), 0, (int)objDatosSerializar.Length);
                var ClienteWeb = new WebClient();
                ClienteWeb.Headers["Content-type"] = "application/json";
                ClienteWeb.Encoding = Encoding.UTF8;
                ClienteWeb.UploadString(URL_WCFUsuarios + "CrearUsuario", "POST", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Usuarios BuscarUsuario(string NroId, string TipoId)
        {
            try
            {
                var ClienteWeb = new WebClient();
                String url = string.Format(URL_WCFUsuarios + "BuscarUsuario/{0}/{1}", NroId, TipoId);
                var JSON = ClienteWeb.DownloadString(url);
                var jsUsuarios = new JavaScriptSerializer();

                return jsUsuarios.Deserialize<Usuarios>(JSON);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ActualizarUsuario(Usuarios DatosActualizar)
        {
            try
            {
                DataContractJsonSerializer objMenoriaFisica = new DataContractJsonSerializer(typeof(Registrado));
                MemoryStream objDatosSerializar = new MemoryStream();
                objMenoriaFisica.WriteObject(objDatosSerializar, DatosActualizar);
                string data = Encoding.UTF8.GetString(objDatosSerializar.ToArray(), 0, (int)objDatosSerializar.Length);
                var ClienteWeb = new WebClient();
                ClienteWeb.Headers["Content-type"] = "application/json";
                ClienteWeb.Encoding = Encoding.UTF8;
                ClienteWeb.UploadString(URL_WCFUsuarios + "ActualizarUsuario", "PUT", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarUsuario(string NroId, string TipoId)
        {
            Registrado EliminarRegistro = new Registrado();
            EliminarRegistro.NroIdUsuario = Convert.ToInt32(NroId);
            EliminarRegistro.TipoIdUsuario = TipoId;
            try
            {
                DataContractJsonSerializer objMenoriaFisica = new DataContractJsonSerializer(typeof(Registrado));
                MemoryStream objDatosSerializar = new MemoryStream();
                objMenoriaFisica.WriteObject(objDatosSerializar, EliminarRegistro);
                string data = Encoding.UTF8.GetString(objDatosSerializar.ToArray(), 0, (int)objDatosSerializar.Length);
                var ClienteWeb = new WebClient();
                ClienteWeb.Headers["Content-type"] = "application/json";
                ClienteWeb.Encoding = Encoding.UTF8;
                ClienteWeb.UploadString(URL_WCFUsuarios + "EliminarUsuario", "DELETE", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}