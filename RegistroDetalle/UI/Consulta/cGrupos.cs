using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistroDetalle.Entidades;
using System.Threading.Tasks;


namespace RegistroDetalle.UI.Consulta
{
    public partial class cGrupos : Form
    {
        public cGrupos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Inicilizando el filtro en true
            Expression<Func<Grupos, bool>> filtro = x => true;

            int id;
            switch (FiltrarComboBox.SelectedIndex)
            {
                case 1: //Id
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.GrupoId == id && (x.Fecha >= Desde_dateTimePicker.Value &&
                    x.Fecha <= Hasta_dateTimePicker.Value);
                    break;
            }
            ConsultarDataGridView.DataSource = BLL.GruposBLL.GetList(filtro);
        }

    }
}
