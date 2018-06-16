
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace RegistroDetalle.DAL.Scripts
{
    public interface JRepositorio<T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> Expression);
        T Buscar(int id);
        bool Guardar(T entity);
        bool Modificar(T entity);
        bool Eliminar(int id);
    }
}
