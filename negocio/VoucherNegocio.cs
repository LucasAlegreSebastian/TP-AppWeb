using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VoucherNegocio
    {
        public List<Voucher> ListarVouchers()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select V.CodigoVoucher,V.FechaCanje from Vouchers as V where V.FechaCanje is null");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.Codigo = (string)datos.Lector["CodigoVoucher"];
                    // aux.Cliente = new Cliente();  para obtener datos del cliente
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

        public List<Voucher> ListarVouchersCanjeados()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select V.CodigoVoucher,V.FechaCanje from Vouchers as V where V.FechaCanje is not null");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.Codigo = (string)datos.Lector["CodigoVoucher"];

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

        public void agregarVoucherDB(string codigoVoucher, int idCliente, DateTime fechaCanje, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Vouchers SET IdCliente = @idCliente, FechaCanje = @fechaCanje, IdArticulo = @idArticulo WHERE CodigoVoucher = @codigoVoucher");
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@fechaCanje", fechaCanje);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.setearParametro("@codigoVoucher", codigoVoucher);
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
