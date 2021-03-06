﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using RegistroDetalle.Entidades;
using System.Threading.Tasks;

namespace RegistroDetalle.Entidades
{
    public class Grupos
    {
        [Key]
        public int GrupoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Grupo { get; set; }
        public int Integrantes { get; set; }

        [StringLength(100)]
        public string Comentarios { get; set; }

        public virtual ICollection<GruposDetalle> Detalle { get; set; }
       
        public Grupos()
        {
            //Es obligatorio inicializar la lista
            this.Detalle = new List<GruposDetalle>();
        }
    
        public void AgregarDetalle(int id, int gruposId, int personasId, string cargo)
        {
            this.Detalle.Add(new GruposDetalle(id, gruposId, personasId, cargo));
        }

    }
}
