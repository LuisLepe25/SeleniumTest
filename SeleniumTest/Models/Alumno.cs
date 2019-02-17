using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Alumno
    {
        private UInt32 Matricula { get; set; }
        private String Nombre { get; set; }

        public Alumno(UInt32 Matricula, String Nombre)
        {
            this.Matricula = Matricula;
            this.Nombre = Nombre;
        }
    }
}
