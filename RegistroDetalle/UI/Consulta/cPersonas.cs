﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroDetalle.Entidades;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroDetalle.UI.Consulta
{
    public partial class cPersonas : Form
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en true
            Expression<Func<Personas, bool>> filtro = x => true;

            int id;
            switch (FiltrarComboBox.SelectedIndex)
            {
                case 0: //Id
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.PersonaId == id
                    && (x.Fecha >= Desde_dateTimePicker.Value && x.Fecha <= Hasta_dateTimePicker.Value);
                    break;

                case 1:// nombre
                    filtro = x => x.Nombres.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= Desde_dateTimePicker.Value && x.Fecha <= Hasta_dateTimePicker.Value);
                    break;

                case 2:// cedula
                    filtro = x => x.Cedula.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= Desde_dateTimePicker.Value && x.Fecha <= Hasta_dateTimePicker.Value);
                    break;

                case 3:// direccion
                    filtro = x => x.Direccion.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= Desde_dateTimePicker.Value && x.Fecha <= Hasta_dateTimePicker.Value);
                    break;

                case 4://telefono
                    filtro = x => x.Telefono.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= Desde_dateTimePicker.Value && x.Fecha <= Hasta_dateTimePicker.Value);
                    break;
            }

            ConsultadataGridView.DataSource = BLL.PersonasBLL.GetList(filtro);

        }
    }
}
