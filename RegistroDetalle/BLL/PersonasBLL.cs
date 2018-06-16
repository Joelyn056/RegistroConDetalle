using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroDetalle.DAL.Scripts;
using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using System.Linq.Expressions;
using System.Data.Entity;
using RegistroDetalle.BLL;

namespace RegistroDetalle.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if(contexto.Personas.Add(persona) !=null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Personas persona = contexto.Personas.Find(id);
                contexto.Personas.Remove(persona);

                if( contexto.SaveChanges() > 0 )
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas persona = new Personas();
            try
            {
                persona = contexto.Personas.Find(id);
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return persona;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> expression) 
        {
            List<Personas> personas = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                personas = contexto.Personas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return personas;
        }
    }
}
