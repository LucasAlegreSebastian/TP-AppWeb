using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select C.Id, C.Documento, C.Nombre, C.Apellido, C.Email, C.Direccion, C.Ciudad, C.CP From Clientes C");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CP = (int)datos.Lector["CP"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarClienteDB(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)" +
                                 "VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP);");
                datos.setearParametro("@Documento", nuevo.Documento);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Ciudad", nuevo.Ciudad);
                datos.setearParametro("@CP", nuevo.CP);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int obtenerIDNuevoCliente()
        {
            AccesoDatos datos = new AccesoDatos();
            int IDNuevoCliente;
            try
            {
                datos.setearConsulta("Select MAX(ID) as UltimoID from Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    IDNuevoCliente = (int)datos.Lector["UltimoID"];
                    return IDNuevoCliente;
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public void modificarCliente(Cliente modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Clientes SET Nombre = @Nombre,Apellido = @Apellido,Email = @Email,Direccion = @Direccion,Ciudad = @Ciudad,CP = @CP WHERE Documento = " + modificado.Documento + "");
                datos.setearParametro("@Documento", modificado.Documento);

                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Apellido", modificado.Apellido);
                datos.setearParametro("@Email", modificado.Email);
                datos.setearParametro("@Direccion", modificado.Direccion);
                datos.setearParametro("@Ciudad", modificado.Ciudad);
                datos.setearParametro("@CP", modificado.CP);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
