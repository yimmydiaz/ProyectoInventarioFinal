using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Parametros
{
    public class PersonaDTO
    {
        
            private int id;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            private string cedula;

            public string Cedula
            {
                get { return cedula; }
                set { cedula = value; }
            }


            private string nombre;

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            private string apellido;

            public string Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }

            private int edad;

            public int Edad
            {
                get { return edad; }
                set { edad = value; }
            }

            private string correo;

            public string Correo
            {
                get { return correo; }
                set { correo = value; }
            }

            private string celular;

            public string Celular
            {
                get { return celular; }
                set { celular = value; }
            }

    }
}
