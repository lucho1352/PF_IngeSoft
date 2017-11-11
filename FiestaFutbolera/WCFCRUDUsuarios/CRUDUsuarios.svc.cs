using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCRUDUsuarios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CRUDUsuarios" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CRUDUsuarios.svc o CRUDUsuarios.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CRUDUsuarios : ICRUDUsuarios
    {
        public bool ActualizarUsuario(Usuarios DatosActualizar)
        {
            using (ConectorDB DBEntidad = new ConectorDB())
            {
                try
                {
                    Usuarios TBUsuarios = DBEntidad.Usuarios.Single(DBU => DBU.NroIdUsuario == DatosActualizar.NroIdUsuario && DBU.TipoIdUsuario == DatosActualizar.TipoIdUsuario);
                    TBUsuarios.NroIdUsuario = DatosActualizar.NroIdUsuario;
                    TBUsuarios.TipoIdUsuario = DatosActualizar.TipoIdUsuario;
                    TBUsuarios.Nombre = DatosActualizar.Nombre;
                    TBUsuarios.Telefono = DatosActualizar.Telefono;
                    DBEntidad.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            };
        }

        public bool ActualizarUsuarioRegistrado(Registrado DatosActualizarR)
        {
            using (ConectorDB DBEntidad = new ConectorDB())
            {
                try
                {
                    Registrado TBRegistrado = DBEntidad.Registrado.Single(DBU => DBU.NroIdUsuario == DatosActualizarR.NroIdUsuario && DBU.TipoIdUsuario == DatosActualizarR.TipoIdUsuario);
                    TBRegistrado.NroIdUsuario = DatosActualizarR.NroIdUsuario;
                    TBRegistrado.TipoIdUsuario = DatosActualizarR.TipoIdUsuario;
                    TBRegistrado.Foto = DatosActualizarR.Foto;
                    TBRegistrado.DirCorreo = DatosActualizarR.DirCorreo;
                    TBRegistrado.Password = DatosActualizarR.Password;
                    DBEntidad.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            };
        }

        public Usuarios BuscarUsuario(string NroId, string TipoId)
        {
            using (ConectorDB DBEntidad = new ConectorDB())
            {
                Int32 Nid = Convert.ToInt32(NroId);

                var usuarios = (from DatosUsuario in DBEntidad.Usuarios
                                where DatosUsuario.NroIdUsuario == Nid && DatosUsuario.TipoIdUsuario.Equals(TipoId)
                                select new
                                {
                                    NroIdUsuario = DatosUsuario.NroIdUsuario,
                                    TipoIdUsuario = DatosUsuario.TipoIdUsuario,
                                    Nombre = DatosUsuario.Nombre,
                                    Telefono = DatosUsuario.Telefono
                                }).ToList()
                            .Select(x => new Usuarios
                            {
                                NroIdUsuario = x.NroIdUsuario,
                                TipoIdUsuario = x.TipoIdUsuario,
                                Nombre = x.Nombre,
                                Telefono = x.Telefono
                            }).ToList();

                if (usuarios.Count > 0)
                {
                    return usuarios.First();
                }
                else
                {
                    return null;
                }
            }
        }

        public Registrado BuscarUsuarioRegistrado(string Correo)
        {

            using (ConectorDB DBEntidad = new ConectorDB())
            {
                var uregistrado = (from DatosUsuario in DBEntidad.Registrado
                                where DatosUsuario.DirCorreo == Correo
                                select new
                                {
                                    NroIdUsuario = DatosUsuario.NroIdUsuario,
                                    TipoIdUsuario = DatosUsuario.TipoIdUsuario,
                                    Foto = DatosUsuario.Foto,
                                    DirCorreo = DatosUsuario.DirCorreo,
                                    Password = DatosUsuario.Password
                                }).ToList()
                            .Select(x => new Registrado
                            {
                                NroIdUsuario = x.NroIdUsuario,
                                TipoIdUsuario = x.TipoIdUsuario,
                                Foto = x.Foto,
                                DirCorreo = x.DirCorreo,
                                Password = x.Password
                            }).ToList();

                if (uregistrado.Count > 0)
                {
                    return uregistrado.First();
                }
                else
                {
                    return null;
                }
            }
        }

        public bool CrearUsuario(Usuarios DatosCrear)
        {
            using (ConectorDB DBEntidad = new ConectorDB())
            {
                try
                {
                    Usuarios TBUsuarios = new Usuarios();
                    TBUsuarios.NroIdUsuario = DatosCrear.NroIdUsuario;
                    TBUsuarios.TipoIdUsuario = DatosCrear.TipoIdUsuario;
                    TBUsuarios.Nombre = DatosCrear.Nombre;
                    TBUsuarios.Telefono = DatosCrear.Telefono;
                    DBEntidad.Usuarios.Add(TBUsuarios);
                    DBEntidad.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            };
        }

        public bool CrearUsuarioRegistrado(Registrado DatosCrearR)
        {
            using (ConectorDB DBEntidad = new ConectorDB())
            {
                try
                {
                    Registrado TBRegistrado = new Registrado();
                    TBRegistrado.NroIdUsuario = DatosCrearR.NroIdUsuario;
                    TBRegistrado.TipoIdUsuario = DatosCrearR.TipoIdUsuario;
                    TBRegistrado.DirCorreo = DatosCrearR.DirCorreo;
                    TBRegistrado.Foto = DatosCrearR.Foto;
                    TBRegistrado.Password = DatosCrearR.Password;
                    DBEntidad.Registrado.Add(TBRegistrado);
                    DBEntidad.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            };
        }

        public bool EliminarUsuario(string NroId, string TipoId)
        {
            using (ConectorDB DBEntidad = new ConectorDB())
            {
                try
                {
                    Int32 Nid = Convert.ToInt32(NroId);
                    Usuarios TBUsuarios = DBEntidad.Usuarios.Single(DBU => DBU.NroIdUsuario == Nid && DBU.TipoIdUsuario == TipoId);
                    DBEntidad.Usuarios.Remove(TBUsuarios);
                    DBEntidad.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            };
        }

        public bool EliminarUsuarioRegistrado(Registrado DatosBorrar)
        {
            String Correo = DatosBorrar.DirCorreo;
            using (ConectorDB DBEntidad = new ConectorDB())
            {
                try
                {
                    Registrado TBRegistrado = DBEntidad.Registrado.Single(DBU => DBU.DirCorreo == Correo);
                    DBEntidad.Registrado.Remove(TBRegistrado);
                    DBEntidad.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            };
        }
    }
}
