﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Detalle_Compra
    {
        public int IdDetalle_Compra { get; set; }
        public int IdCompra { get; set; }
        public Producto oProducto { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaRegistro { get; set; }




    }
}
