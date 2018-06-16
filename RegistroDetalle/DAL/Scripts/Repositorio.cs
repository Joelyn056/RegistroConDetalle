using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RegistroDetalle.DAL.Scripts
{
    public class Repositorio<T> : IDisposable, JRepositorio<T> where T : class
    {
        internal Contexto Pcontexto;

        public Repositorio(Contexto contexto)
        {
            Pcontexto = contexto;
        }

        public bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if(Pcontexto.Set<T>().Add(entity) !=null)
                {
                    Pcontexto.SaveChanges(); //Guardar Cambios
                    paso = true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Modificar(T entity)
        {
            bool paso = false;

            try
            {
                Pcontexto.Entry(entity).State = EntityState.Modified;
                if(Pcontexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                T entity = Pcontexto.Set<T>().Find(id);

                Pcontexto.Set<T>().Remove(entity);

                if (Pcontexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                Pcontexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public T Buscar(int id)
        {
            T entity;
            try
            {
                entity = Pcontexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = Pcontexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public void Dispose()
        {
            Pcontexto.Dispose();
        }
    }
}
