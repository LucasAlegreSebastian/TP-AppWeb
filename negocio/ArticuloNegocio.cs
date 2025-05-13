using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id,A.Codigo,A.Nombre,A.Descripcion,M.Descripcion as 'Marca',C.Descripcion as 'Categoria',A.Precio, A.IdMarca, A.IdCategoria  from ARTICULOS as A ,MARCAS as M ,CATEGORIAS as C where A.IdMarca=M.Id and A.IdCategoria=C.Id ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (float)(decimal)datos.Lector["Precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

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

        public List<Articulo> listarConSp()
        {

            /*
             * 
           create procedure listarPremios as
         select
        A.Id'ArticuloID',A.Nombre'ArticuloNombre',A.Descripcion'ArticuloDescripcion',A.Precio'ArticuloPrecio',
        M.Id'MarcaId',M.Descripcion'MarcaDescripcion',
        C.Id'CategoriaId',C.Descripcion'CategoriaDescripcion',
        I.ImagenUrl'ImagenUrl'
        from ARTICULOS as A
        inner join IMAGENES as I on A.Id=I.IdArticulo
        inner join MARCAS as M on A.IdMarca=M.Id
        inner join CATEGORIAS as C on A.IdCategoria=C.Id
                        
             
             * */
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearProcedimiento("listarPremios");
                datos.setearConsulta("select A.Id'ArticuloID',A.Nombre'ArticuloNombre',A.Descripcion'ArticuloDescripcion',A.Precio'ArticuloPrecio',M.Id'MarcaId',M.Descripcion'MarcaDescripcion',C.Id'CategoriaId',C.Descripcion'CategoriaDescripcion',I.ImagenUrl'ImagenUrl'from ARTICULOS as A inner join IMAGENES as I on A.Id=I.IdArticulo inner join MARCAS as M on A.IdMarca=M.Id inner join CATEGORIAS as C on A.IdCategoria=C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int ArticuloId = (int)datos.Lector["ArticuloID"];
                    ///guardamos el id de articulo en variable
                    ///
                    Articulo articulo = lista.Find(a => a.Id == ArticuloId);
                    ///lo buscamos si esta en la lista ( si es correcto es que es el mismo idarticulo)


                    if (articulo == null)/// creamos el articulo si no existe
                    {
                        articulo = new Articulo
                        {
                            Id = ArticuloId,
                            Nombre = (string)datos.Lector["ArticuloNombre"],
                            Descripcion = (string)datos.Lector["ArticuloDescripcion"],
                            Precio = (float)(decimal)datos.Lector["ArticuloPrecio"],
                            Marca = new Marca
                            {
                                Id = (int)datos.Lector["MarcaId"],
                                Descripcion = (string)datos.Lector["MarcaDescripcion"]
                            },
                            Categoria = new Categoria
                            {
                                Id = (int)datos.Lector["CategoriaId"],
                                Descripcion = (string)datos.Lector["CategoriaDescripcion"]
                            },
                            Imagenes = new List<Imagen>()
                        };
                        lista.Add(articulo);
                    }

                    // al mismo articulo le agregamos las imagenes a la lista
                    articulo.Imagenes.Add(new Imagen
                    {
                        ImagenUrl = (string)datos.Lector["ImagenUrl"]
                    });
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
