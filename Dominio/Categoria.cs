using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int idCat { get; set; }
        public string descripcionCat { get; set; }
        public override string ToString()
        {
            return descripcionCat;
        }
    }
}
