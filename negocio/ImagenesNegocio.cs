using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ImagenesNegocio
    {

        /*public list<imagen> listarconsp()
        {
            list<imagen> lista = new list<imagen>();
            accesodatos datos = new accesodatos();

            try
            {

                //id,idarticulo,imagenurl,
                //articulonombre,articulodescripcion,articuloprecio,
                //marcaid,marcadescripcion,
                //categoriaid,categoriadescripcion

                datos.setearprocedimiento("listarimagenes");
                datos.ejecutarlectura();
                while (datos.lector.read())
                {
                    imagen aux = new imagen();
                    aux.id = (int)datos.lector["id"];

                    aux.articulo = new articulo();
                    aux.articulo.id = (int)datos.lector["idarticulo"];
                    aux.articulo.nombre = (string)datos.lector["articulonombre"];
                    aux.articulo.descripcion = (string)datos.lector["articulodescripcion"];

                    aux.articulo.marca = new marca();
                    aux.articulo.marca.id = (int)datos.lector["marcaid"];
                    aux.articulo.marca.descripcion = (string)datos.lector["marcadescripcion"];//nombre

                    aux.articulo.categoria = new categoria();
                    aux.articulo.categoria.id = (int)datos.lector["categoriaid"];
                    aux.articulo.categoria.descripcion = (string)datos.lector["categoriadescripcion"];//nombre


                    aux.imagenurl = (string)datos.lector["imagenurl"].tostring();


                    lista.add(aux);
                }



                return lista;
            }
            catch (exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarconexion();
            }
        }*/


        public List<Imagen> ListarImagenesPremios()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select I.Id,I.IdArticulo,I.ImagenUrl from IMAGENES as I");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];

                    aux.Articulo = new Articulo();
                    aux.Articulo.Id = (int)datos.Lector["IdArticulo"];

                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"].ToString();


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
    }

}
