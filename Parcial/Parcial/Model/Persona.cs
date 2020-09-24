using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using SQLite;

namespace Parcial.Model
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }



    }
}
