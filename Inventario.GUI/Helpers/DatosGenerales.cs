using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Helpers
{
    public class DatosGenerales
    {
        public static int RegistroPorPagina =
           Int32.Parse(ConfigurationManager.AppSettings["registroPorPagina"].ToString());

        public static String RutaArchivosProductos =
          ConfigurationManager.AppSettings["rutaArchivosProducto"].ToString();

        public static String RutaMostrarArchivosProductos =
          ConfigurationManager.AppSettings["rutaMostrarArchivosProducto"].ToString();

        public static String CarpetaFotosProductosEliminadas =
        ConfigurationManager.AppSettings["carpetaFotosProductoEliminadas"].ToString();
    }
}