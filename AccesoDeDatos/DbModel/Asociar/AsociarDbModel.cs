using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Asociar
{
    public class AsociarDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string ubicacion;

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        private int id_Producto;

        public int Id_Producto
        {
            get { return id_Producto; }
            set { id_Producto = value; }
        }

        private int id_Persona;

        public int Id_Persona
        {
            get { return id_Persona; }
            set { id_Persona = value; }
        }

        private string nombreProducto;

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        private string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }

    }
}
