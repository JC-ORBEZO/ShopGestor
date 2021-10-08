using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> aux = new List<Articulo>();
            AccesoDatos dato = new AccesoDatos();
            dato.setearConsulta("SELECT ARTICULOS.Id,ARTICULOS.Codigo,ARTICULOS.Nombre,ARTICULOS.Descripcion,ARTICULOS.ImagenUrl,MARCAS.Descripcion AS Marca,CATEGORIAS.Descripcion AS Categoria,ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca=MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id");
            try
            {
                dato.ejecutarLectura();                
                while (dato.Lector.Read())
                {
                    Articulo nuevo = new Articulo();
                    nuevo.id = (int)dato.Lector["Id"];
                    nuevo.codigo = (string)dato.Lector["Codigo"];
                    nuevo.nombre = (string)dato.Lector["Nombre"];
                    nuevo.descripcion = (string)dato.Lector["Descripcion"];
                    nuevo.urlImagen = (string)dato.Lector["ImagenUrl"];
                    nuevo.marca = new Marca();
                    nuevo.marca.descripcionMarca = (string)dato.Lector["Marca"];
                    nuevo.categoria = new Categoria();
                    nuevo.categoria.descripcionCat = (string)dato.Lector["Categoria"];
                    nuevo.precio = (decimal)dato.Lector["Precio"];
                    aux.Add(nuevo);
                }
                dato.cerrarConexion();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public List<Articulo> buscar(string item,string text)
        {
            List<Articulo> aux = new List<Articulo>();
            AccesoDatos dato = new AccesoDatos();
            try
            {                
                switch (item)
                {
                    case "ID":
                        dato.setearConsulta("SELECT ARTICULOS.Id,ARTICULOS.Codigo,ARTICULOS.Nombre,ARTICULOS.Descripcion,ARTICULOS.ImagenUrl,MARCAS.Descripcion AS Marca,CATEGORIAS.Descripcion AS Categoria,ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE ARTICULOS.Id = '" + text + "'");
                        break;
                    case "CODIGO":
                        dato.setearConsulta("SELECT ARTICULOS.Id, ARTICULOS.Codigo, ARTICULOS.Nombre, ARTICULOS.Descripcion, ARTICULOS.ImagenUrl, MARCAS.Descripcion AS Marca, CATEGORIAS.Descripcion AS Categoria, ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE ARTICULOS.Codigo = '" + text + "'");
                        break;
                    case "NOMBRE":
                        dato.setearConsulta("SELECT ARTICULOS.Id, ARTICULOS.Codigo, ARTICULOS.Nombre, ARTICULOS.Descripcion, ARTICULOS.ImagenUrl, MARCAS.Descripcion AS Marca, CATEGORIAS.Descripcion AS Categoria, ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE ARTICULOS.Nombre = '" + text + "'");
                        break;
                    case "MARCA":
                        dato.setearConsulta("SELECT ARTICULOS.Id, ARTICULOS.Codigo, ARTICULOS.Nombre, ARTICULOS.Descripcion, ARTICULOS.ImagenUrl, MARCAS.Descripcion AS Marca, CATEGORIAS.Descripcion AS Categoria, ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE MARCAS.Descripcion = '" + text + "'");
                        break;
                    case "CATEGORIA":
                        dato.setearConsulta("SELECT ARTICULOS.Id, ARTICULOS.Codigo, ARTICULOS.Nombre, ARTICULOS.Descripcion, ARTICULOS.ImagenUrl, MARCAS.Descripcion AS Marca, CATEGORIAS.Descripcion AS Categoria, ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE CATEGORIAS.Descripcion = '" + text + "'");
                        break;
                    case "PRECIO":
                        dato.setearConsulta("SELECT ARTICULOS.Id, ARTICULOS.Codigo, ARTICULOS.Nombre, ARTICULOS.Descripcion, ARTICULOS.ImagenUrl, MARCAS.Descripcion AS Marca, CATEGORIAS.Descripcion AS Categoria, ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE ARTICULOS.Precio = '" + text + "'");
                        break;
                    default:
                        break;
                }
                dato.ejecutarLectura();
                while (dato.Lector.Read())
                {
                    Articulo nuevo = new Articulo();
                    nuevo.id = (int)dato.Lector["Id"];
                    nuevo.codigo = (string)dato.Lector["Codigo"];
                    nuevo.nombre = (string)dato.Lector["Nombre"];
                    nuevo.descripcion = (string)dato.Lector["Descripcion"];
                    nuevo.urlImagen = (string)dato.Lector["ImagenUrl"];
                    nuevo.marca = new Marca();
                    nuevo.marca.descripcionMarca = (string)dato.Lector["Marca"];
                    nuevo.categoria = new Categoria();
                    nuevo.categoria.descripcionCat = (string)dato.Lector["Categoria"];
                    nuevo.precio = (decimal)dato.Lector["Precio"];
                    aux.Add(nuevo);
                }
                dato.cerrarConexion();
            }
            catch (Exception ex)
            {
                dato.cerrarConexion();
                return aux;

            }
            

            return aux;
        } 
        public void agregar(Articulo aux)
        {
            AccesoDatos dato = new AccesoDatos();
            try
            {
                dato.setearConsulta("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,IdMarca, IdCategoria,ImagenUrl,Precio)VALUES('" + aux.codigo + "','" + aux.nombre + "','" + aux.descripcion + "','" + aux.marca.idMarca + "','" + aux.categoria.idCat + "','" + aux.urlImagen + "','" + aux.precio + "')");
                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            dato.cerrarConexion();
        }
        public Articulo buscarPorId(int id)
        {
            AccesoDatos dato = new AccesoDatos();
            dato.setearConsulta("SELECT ARTICULOS.Id,ARTICULOS.Codigo,ARTICULOS.Nombre,ARTICULOS.Descripcion,ARTICULOS.ImagenUrl,MARCAS.Descripcion AS Marca,CATEGORIAS.Descripcion AS Categoria,ARTICULOS.Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca=MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE ARTICULOS.Id='"+ id +"'");
            dato.ejecutarLectura();
            //dato.Lector.Read();
            Articulo nuevo = new Articulo();
            while (dato.Lector.Read())
            {                
                nuevo.id = (int)dato.Lector["Id"];
                nuevo.codigo = (string)dato.Lector["Codigo"];
                nuevo.nombre = (string)dato.Lector["Nombre"];
                nuevo.descripcion = (string)dato.Lector["Descripcion"];
                nuevo.urlImagen = (string)dato.Lector["ImagenUrl"];
                nuevo.marca = new Marca();
                nuevo.marca.descripcionMarca = (string)dato.Lector["Marca"];
                nuevo.categoria = new Categoria();
                nuevo.categoria.descripcionCat = (string)dato.Lector["Categoria"];
                nuevo.precio = (decimal)dato.Lector["Precio"];
            }                
            dato.cerrarConexion();
            return nuevo;
        }
        public void Modificar(Articulo aux, int id)
        {
            AccesoDatos dato = new AccesoDatos();
            try
            {
                dato.setearConsulta("UPDATE ARTICULOS SET ARTICULOS.Codigo = '" + aux.codigo + "', ARTICULOS.Nombre = '" + aux.nombre + "', ARTICULOS.Descripcion = '" + aux.descripcion + "', ARTICULOS.IdMarca = '" + aux.marca.idMarca + "', ARTICULOS.IdCategoria = '" + aux.categoria.idCat + "', ARTICULOS.ImagenUrl = '" + aux.urlImagen + "', ARTICULOS.Precio = '" + aux.precio + "' WHERE ARTICULOS.Id = '" + id + "'");
                dato.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            dato.cerrarConexion();
        }
    }
}
