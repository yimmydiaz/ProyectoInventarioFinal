using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Parametros
{
    public class EspacioDTO
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

        public string NombrePiso { get; set; }
    }
}
