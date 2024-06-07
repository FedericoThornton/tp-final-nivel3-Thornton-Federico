using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Runtime.Remoting.Channels;
using Microsoft.SqlServer.Server;
using System.Data.Common;
using System.Net;
using System.Globalization;
using System.Reflection;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarconSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("StoredListar");
                 
                datos.ejecutarLecturar();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Nombre"))))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Descripcion"))))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ImagenUrl"))))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Precio"))))
                        aux.Precio = (decimal)datos.Lector["Precio"];



                    aux.Tipo = new Categoria();
                    aux.Tipo.Id = (int)datos.Lector["idCategoria"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> listarFavorito(string idUser)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("");
                datos.ejecutarLecturar();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Nombre"))))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Descripcion"))))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ImagenUrl"))))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Precio"))))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Tipo = new Categoria();
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Tipo"))))
                        aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Marca = new Marca();
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Marca"))))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            } finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarFavorito(int IdArticulo, Usuario IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@IdUser, @IdArticulo)");
                datos.setearParamentro("@IdUser", IdUser);
                datos.setearParamentro("@IdArticulo", IdArticulo);
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
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
           
            try
            {

                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, Codigo, Nombre, A.Descripcion, C.Descripcion Tipo, M.Descripcion Marca, ImagenUrl, Precio, A.IdCategoria, A.IdMarca  from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id  ";
                comando.Connection = conexion;
                if (id != "")
                {
                    comando.CommandText += " and A.Id =" + id;
                }
              
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    if (!(lector.IsDBNull(lector.GetOrdinal("Nombre"))))
                        aux.Nombre = (string)lector["Nombre"];
                    if (!(lector.IsDBNull(lector.GetOrdinal("Descripcion"))))
                        aux.Descripcion = (string)lector["Descripcion"];
                    if (!(lector.IsDBNull(lector.GetOrdinal("ImagenUrl"))))
                        aux.ImagenUrl = (string)lector["ImagenUrl"];
                    if (!(lector.IsDBNull(lector.GetOrdinal("Precio"))))
                         aux.Precio = (decimal)lector["Precio"];


                    aux.Tipo = new Categoria();
                    if (!(lector.IsDBNull(lector.GetOrdinal("IdCategoria"))))
                        aux.Tipo.Id = (int)lector["IdCategoria"];
                    if (!(lector.IsDBNull(lector.GetOrdinal("Tipo"))))
                        aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Marca = new Marca();
                    if (!(lector.IsDBNull(lector.GetOrdinal("IdMarca"))))
                        aux.Marca.Id = (int)lector["IdMarca"];
                    if (!(lector.IsDBNull(lector.GetOrdinal("Marca"))))
                        aux.Marca.Descripcion = (string)lector["Marca"];

                    lista.Add(aux);
                }




                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { conexion.Close(); }


        }

        public void agregarconSP(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("StoredAltaArticulo");
                datos.setearParamentro("@Codigo", nuevo.Codigo);
                datos.setearParamentro("@Nombre", nuevo.Nombre);
                datos.setearParamentro("@idMarca", nuevo.Marca.Id);
                datos.setearParamentro("@Descripcion", nuevo.Descripcion);
                datos.setearParamentro("@Precio", nuevo.Precio);
                datos.setearParamentro("@idCategoria", nuevo.Tipo.Id);
                datos.setearParamentro("@ImagenUrl", nuevo.ImagenUrl);
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

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, ImagenUrl, Precio, IdMarca, IdCategoria) values (@Codigo,@Nombre,@Descripcion,@ImagenUrl,@Precio,@idMarca,@idCategoria)");
                datos.setearParamentro("@Codigo", nuevo.Codigo);
                datos.setearParamentro("@Nombre", nuevo.Nombre);
                datos.setearParamentro("@idMarca", nuevo.Marca.Id);
                datos.setearParamentro("@Descripcion", nuevo.Descripcion);
                datos.setearParamentro("@Precio", nuevo.Precio);
                datos.setearParamentro("@idCategoria", nuevo.Tipo.Id);
                datos.setearParamentro("@ImagenUrl", nuevo.ImagenUrl);
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

        public void modificarconSP(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("StoredModificarArticulo");
                datos.setearParamentro("@codigo", articulo.Codigo);
                datos.setearParamentro("@nombre", articulo.Nombre);
                datos.setearParamentro("@descripcion", articulo.Descripcion);
                datos.setearParamentro("@IdMarca", articulo.Marca.Id);
                datos.setearParamentro("@IdCategoria", articulo.Tipo.Id);
                datos.setearParamentro("@ImagenUrl", articulo.ImagenUrl);
                datos.setearParamentro("@precio", articulo.Precio);
                datos.setearParamentro("@id", articulo.Id);

                datos.ejecutarAccion();
            }


            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @precio where Id = @id");
                datos.setearParamentro("@codigo", articulo.Codigo);
                datos.setearParamentro("@nombre", articulo.Nombre);
                datos.setearParamentro("@descripcion", articulo.Descripcion);
                datos.setearParamentro("@IdMarca", articulo.Marca.Id);
                datos.setearParamentro("@IdCategoria", articulo.Tipo.Id);
                datos.setearParamentro("@ImagenUrl", articulo.ImagenUrl);
                datos.setearParamentro("@precio", articulo.Precio);
                datos.setearParamentro("@id", articulo.Id);

                datos.ejecutarAccion();
            }


            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

        public void eliminar (int id)
        {
            try
            {
                AccesoDatos datos =  new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id =@id");
                datos.setearParamentro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            } 
        
                      
        } 
        

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
               string consulta = "select Codigo, Nombre, A.Descripcion, C.Descripcion as Tipo, M.Descripcion as Marca, ImagenUrl, Precio, A.IdCategoria, A.IdMarca, A.Id from ARTICULOS A, CATEGORIAS C, MARCAS M  where A.IdCategoria = C.Id and A.IdMarca = M.Id and ";

                switch (campo)
                {

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "Nombre like '%" + filtro + "%'";

                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio >" + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio <" + filtro;
                                break;

                            default:
                                consulta += "Precio =" + filtro;
                                break;
                        }

                        break;
                    case "Tipo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;
                            case "termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";

                                break;
                        }

                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M. Descripcion like '" + filtro + "%'";
                                break;
                            case "termina con":
                                consulta += "M. Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "M. Descripcion like '%" + filtro + "%'";

                                break;
                        }
                        break;

                }

                 datos.setearConsulta(consulta);
                datos.ejecutarLecturar();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Nombre"))))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Descripcion"))))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ImagenUrl"))))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Precio"))))
                        aux.Precio = (decimal)datos.Lector["Precio"];



                    aux.Tipo = new Categoria();
                    aux.Tipo.Id = (int)datos.Lector["idCategoria"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
