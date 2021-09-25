﻿using System;
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
    }
}
