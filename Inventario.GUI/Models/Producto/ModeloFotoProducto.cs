using Inventario.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Producto
{
    public class ModeloFotoProducto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private string nombreFoto;

        public string NombreFoto
        {
            get { return nombreFoto; }
            set { nombreFoto = value; }
        }

    }
}