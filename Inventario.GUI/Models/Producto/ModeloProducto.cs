using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Producto
{
    public class ModeloProducto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string serialProducto;

        public string SerialProducto
        {
            get { return serialProducto; }
            set { serialProducto = value; }
        }
        private int id_Marca;

        public int Id_Marca
        {
            get { return id_Marca; }
            set { id_Marca = value; }
        }
        private int id_Categoria;

        public int Id_Categoria
        {
            get { return id_Categoria; }
            set { id_Categoria = value; }
        }
        private int id_TipoProducto;

        public int Id_TipoProducto
        {
            get { return id_TipoProducto; }
            set { id_TipoProducto = value; }
        }

        private int id_Espacio;

        public int Id_Espacio
        {
            get { return id_Espacio; }
            set { id_Espacio = value; }
        }
        private string nombreCategoria;

        [DisplayName("Categoria")]
        public string NombreCategoria
        {
            get { return nombreCategoria; }
            set { nombreCategoria = value; }
        }

        private string nombreMarca;

        [DisplayName("Marca")]
        public string NombreMarca
        {
            get { return nombreMarca; }
            set { nombreMarca = value; }
        }

        private string nombreTipoProducto;

        [DisplayName("Tipo Producto")]
        public string NombreTipoProducto
        {
            get { return nombreTipoProducto; }
            set { nombreTipoProducto = value; }
        }

        private string nombreEspacio;

        [DisplayName("Espacio")]
        public string NombreEspacio
        {
            get { return nombreEspacio; }
            set { nombreEspacio = value; }
        }

    }
}