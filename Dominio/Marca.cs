﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Marca
    {
        public int idMarca { get; set; }
        public string descripcionMarca { get; set; }
        public override string ToString()
        {
            return descripcionMarca;
        }
    }
}
