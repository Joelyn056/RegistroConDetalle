using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroDetalle.Entidades;
using System.Threading.Tasks;

namespace RegistroDetalle.Entidades
{
    public class GruposDetalle
    {
        public int Id { get; set; }
        public int GruposId { get; set; }
        public int PersonasId { get; set; }

        [ForeignKey("PersonasId")]
        public virtual Personas Persona { get; set; }
        public string Cargo { get; set; }

        public GruposDetalle()
        {
            this.Id = 0;
            this.GruposId = 0;
        }


        public GruposDetalle(int id, int gruposId, int personaId, string cargo)
        {
            this.Id = id;
            this.GruposId = gruposId;
            this.PersonasId = personaId;
            this.Cargo = cargo;
        }
    }
}
