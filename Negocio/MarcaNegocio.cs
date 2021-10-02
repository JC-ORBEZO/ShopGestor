using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    class MarcaNegocio
    {
        public List<Marca> listar(){
            List<Marca> aux = new List<Marca>();
            AccesoDatos dato = new AccesoDatos();
            try
            {
                dato.setearConsulta("SELECT MARCA.Id, MARCA.Descripcion FROM MARCA");
                dato.ejecutarLectura();
                while (dato.Lector.Read())
                {
                    Marca extra = new Marca();
                    extra.idMarca = (int)dato.Lector["Id"];
                    extra.descripcionMarca = (string)dato.Lector["Descripcion"];
                    aux.Add(extra);                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dato.cerrarConexion();
            return aux;
        }
    }
}
