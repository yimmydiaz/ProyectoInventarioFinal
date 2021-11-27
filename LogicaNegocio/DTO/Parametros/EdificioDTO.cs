using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Parametros
{
    public class EdificioDTO
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

        public string NombreSede { get; set; }
    }
}
