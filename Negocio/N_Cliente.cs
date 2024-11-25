using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Cliente
    {
        public D_Cliente obj_cliente = new D_Cliente();
        public List<Cliente> Listar()
        {
            return obj_cliente.Listar();
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            int clientegenerado = 0; // Variable para almacenar el ID del cliente generado
            Mensaje = string.Empty;   // Inicializar el mensaje de salida

            // Validar campos de entrada
            if (string.IsNullOrWhiteSpace(obj.Documento) ||
                string.IsNullOrWhiteSpace(obj.Primer_Nombre) ||
                string.IsNullOrWhiteSpace(obj.Primer_Apellido))
            {
                Mensaje = "Todos los campos son obligatorios.";
                return 0; // Retorna 0 si hay campos vacíos
            }

            // Registrar cliente en la capa de datos
            clientegenerado = obj_cliente.Registrar(obj, out Mensaje);

            // Verificar el resultado del registro
            if (clientegenerado == 0)
            {
                Mensaje = "Error al registrar el cliente: " + Mensaje;
            }
            
            return clientegenerado; // Retornar el ID del cliente generado
        }


        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Cliente\n";
            }

            if (obj.Primer_Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Cliente\n";
            }

            if (obj.Primer_Apellido == "")
            {
                Mensaje += "Es necesario el Apellido del Cliente\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_cliente.Editar(obj, out Mensaje);
            }


        }

        public bool ELiminar(Cliente obj, out string Mensaje)
        {
            return obj_cliente.Eliminar(obj, out Mensaje);
        }

    }
}
