using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Usuario
    {
        public D_Usuario obj_usuario = new D_Usuario();

        public List<Usuario> Listar()
        {
            return obj_usuario.Listar();
        }


        public int Registrar(Usuario obj, out string Mensaje)
        {
            int usuariogenerado = 0;
            Mensaje = string.Empty;

            // Validar datos de entrada
            if (string.IsNullOrWhiteSpace(obj.Documento) ||
                string.IsNullOrWhiteSpace(obj.PrimerNombre) ||
                string.IsNullOrWhiteSpace(obj.PrimerApellido) ||
                string.IsNullOrWhiteSpace(obj.Clave) ||
                obj.oRol == null ||
                obj.Estado == null)
            {
                Mensaje = "Todos los campos son obligatorios.";
                return 0; // Retorna 0 si hay campos vacíos
            }

            // Registrar usuario en la capa de datos
            usuariogenerado = obj_usuario.Registrar(obj, out Mensaje);

            // Verificar el resultado del registro
            if (usuariogenerado == 0)
            {
                Mensaje = "Error al registrar el usuario: " + Mensaje;
            }

            return usuariogenerado;
        }



        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del usuario\n";
            }

            if (obj.PrimerNombre == "")
            {
                Mensaje += "Es necesario el nombre del usuario\n";
            }

            if (obj.PrimerApellido == "")
            {
                Mensaje += "Es necesario el Apellido del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario La clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_usuario.Editar(obj, out Mensaje);
            }

            
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return obj_usuario.Eliminar(obj, out Mensaje);
        }

    }
}
