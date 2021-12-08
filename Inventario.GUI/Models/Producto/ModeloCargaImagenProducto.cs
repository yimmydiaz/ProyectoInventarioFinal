using Inventario.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Producto
{
    public class ModeloCargaImagenProducto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private HttpPostedFileBase archivo;

        [Required]
        public HttpPostedFileBase Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        private IEnumerable<ModeloFotoProducto> listaImagenesProducto;

        public IEnumerable<ModeloFotoProducto> ListaImagenesProducto
        {
            get { return listaImagenesProducto; }
            set { listaImagenesProducto = value; }
        }

        private String rutaImagenProducto= DatosGenerales.RutaMostrarArchivosProductos;

        public String RutaImagenProducto
        {
            get { return rutaImagenProducto; }

        }

    }
}