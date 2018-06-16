using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroDetalle.Entidades
{
    // public para hacer visibles las demas capas
    public class Personas
    {
        [Key]// llave primaria
        public int PersonaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }



        // Propiedades de la forma corta
        public Personas()
        {

        }

        public override string ToString()
        {
            return this.Nombres;
        }
    }
}
