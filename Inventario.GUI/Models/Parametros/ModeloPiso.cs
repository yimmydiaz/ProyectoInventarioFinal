using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloPiso
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

        private int numeroPiso;

        public int NumeroPiso
        {
            get { return numeroPiso; }
            set { numeroPiso = value; }
        }

        private int id_Edificio;

        public int Id_Edificio
        {
            get { return id_Edificio; }
            set { id_Edificio = value; }
        }

        [DisplayName("Piso")]
        public string NombreEdificio { get; set; }
    }
}