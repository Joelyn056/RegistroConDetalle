using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroDetalle.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroDetalle.Entidades;
using RegistroDetalle.BLL.Tests;



namespace RegistroDetalle.BLL.Tests
{
    [TestClass()]
    public class GruposBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Grupos grupos = new Grupos
            {
                Fecha = DateTime.Now,
                Comentarios = "Fue Bueno"
            };

            //Si no estan creados los grupos da error
           grupos.Detalle.Add(new GruposDetalle(0,0,1, ));
           grupos.Detalle.Add(new GruposDetalle(0,0,2, ));

            bool paso = GruposBLL.Guardar(grupos);
            Assert.AreEqual(true, paso);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            int IdGrupos = GruposBLL.GetList(x => true)[0].GrupoId;
            Grupos grupos = GruposBLL.Buscar(IdGrupos);

            //Agreggar todo
            grupos.Detalle.Add(new GruposDetalle(0, grupos.GrupoId,2,3));

            bool paso = GruposBLL.Modificar(grupos);
            Assert.AreEqual(true, paso);

           
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = BLL.GruposBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Grupos grupo = new Grupos();
            grupo = BLL.GruposBLL.Buscar(2);
            Assert.IsNotNull(grupo);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = BLL.GruposBLL.GetList(g => true);
            Assert.IsNotNull(lista);
        }
    }
}