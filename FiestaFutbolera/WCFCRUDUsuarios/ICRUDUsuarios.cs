using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFCRUDUsuarios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICRUDUsuarios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICRUDUsuarios
    {
        /*
         * Métodos para usuarios registrados
         */
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CrearUsuarioRegistrado", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool CrearUsuarioRegistrado(Registrado DatosCrearR);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "BuscarUsuarioRegistrado/{Correo}", ResponseFormat = WebMessageFormat.Json)]
        Registrado BuscarUsuarioRegistrado(string Correo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "ActualizarUsuarioRegistrado", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool ActualizarUsuarioRegistrado(Registrado DatosActualizarR);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "EliminarUsuarioRegistrado", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool EliminarUsuarioRegistrado(Registrado DatosBorrar);

        /*
         * Métodos para usuarios NO registrados
         */
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CrearUsuario", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool CrearUsuario(Usuarios DatosCrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "BuscarUsuario/{NroID}/{TipoID}", ResponseFormat = WebMessageFormat.Json)]
        Usuarios BuscarUsuario(string NroId, string TipoId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "ActualizarUsuario", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool ActualizarUsuario(Usuarios DatosActualizar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "EliminarUsuario/{NroID}/{TipoID}", ResponseFormat = WebMessageFormat.Json)]
        bool EliminarUsuario(string NroId, string TipoId);
    }
}

