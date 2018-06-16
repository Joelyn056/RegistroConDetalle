using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroDetalle.UI.Consulta;
using RegistroDetalle.UI.Registro;
using System.Threading.Tasks;

namespace RegistroDetalle
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
             // Registro Personas
        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rPersonas().Show();
        }

           // Registo Grupos
        private void visitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RGrupos().Show();
        }

        // Consulta Personas
        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new cPersonas().Show();
        }

        // Consulta Grupos
        private void visitasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new cGrupos().Show();
        }
        // Grupo
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            new RGrupos().Show();
        }

        //Personas
        private void PersonastoolStripButton_Click_1(object sender, EventArgs e)
        {
            new RGrupos().Show();
        }
    }
}
