using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO
{
    public class PisoDTO
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

        public string NombreEdificio { get; set; }
    }
}
