using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloEdificio
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

        private int id_sede;

        public int Id_Sede
        {
            get { return id_sede; }
            set { id_sede = value; }
        }

        [DisplayName("Sede")]
        public string NombreSede { get; set; }
    }
}