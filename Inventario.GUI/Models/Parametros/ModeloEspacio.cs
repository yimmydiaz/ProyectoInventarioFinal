using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloEspacio
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

        private int id_piso;

        public int Id_Piso
        {
            get { return id_piso; }
            set { id_piso = value; }
        }

        [DisplayName("Piso")]
        public string NombrePiso { get; set; }
    }
}