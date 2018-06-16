using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroDetalle.DAL.Scripts;
using RegistroDetalle.Entidades;
using RegistroDetalle.BLL;
using System.Threading.Tasks;

namespace RegistroDetalle.UI.Registro
{
    public partial class RGrupos : Form
    {
        public RGrupos()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Grupos grupos = RegistroDetalle.BLL.GruposBLL.Buscar(id);

            if (grupos != null)
            {
                LlenarCampos(grupos);
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            fechaDateTimePicker.Value = DateTime.Now;
            comentariosTextBox.Clear();

            detalleDataGridView.DataSource = null;
            MyerrorProvider.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Grupos grupo;
            bool Paso = true;

            if(HayErrores())
            {
                MessageBox.Show("Revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            grupo = LlenaClase();

            //Determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)
                Paso = RegistroDetalle.BLL.GruposBLL.Guardar(grupo);
            else
                //Todo: Validar que exista.
                Paso = RegistroDetalle.BLL.GruposBLL.Modificar(grupo);

            //Informar el resultado
            if (Paso)
            {
                NuevoButton.PerformClick();
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se puedo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            //Todo Validar que Exita
            if (RegistroDetalle.BLL.GruposBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<GruposDetalle> detalle = new List<GruposDetalle>();

            if (detalleDataGridView.DataSource != null)
            {
                detalle = (List<GruposDetalle>)detalleDataGridView.DataSource;
            }

            //Agregar un nuevo detalle con los datos introducidos
            detalle.Add(
                new GruposDetalle(
                  id: 0,
                  gruposId: (int)IdnumericUpDown.Value,
                  personaId: (int)PersonacomboBox.SelectedValue,
                  cargo: (string)CargotextBox.Text
                ));
            //Cargar el detalle al Grid
            detalleDataGridView.DataSource = null;
            detalleDataGridView.DataSource = detalle;
        }

        private void LlenarComboBox()
        {
            Repositorio<Personas> repositorio = new Repositorio<Personas>(new Contexto());
            PersonacomboBox.DataSource = repositorio.GetList(c => true);
            PersonacomboBox.ValueMember = "PersonaId";
            PersonacomboBox.DisplayMember = "Nombres";
        }

        private Grupos LlenaClase()
        {
            Grupos grupo = new Grupos();

            grupo.GrupoId = Convert.ToInt32(IdnumericUpDown.Value);
            grupo.Fecha = fechaDateTimePicker.Value;
            grupo.Comentarios = comentariosTextBox.Text;

            //Agregar cada linea del grid al detalle
            foreach (DataGridViewRow item in detalleDataGridView.Rows)
            {
                grupo.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["GrupoId"].Value),
                    ToInt(item.Cells["PersonaId"].Value),
                    (item.Cells["Cargo"].ToString())
                  );
            }

            return grupo;
        }

        private void LlenarCampos(Grupos grupo)
        {
            IdnumericUpDown.Value = grupo.GrupoId;
            fechaDateTimePicker.Value = grupo.Fecha;
            NombretextBox.Text = grupo.Descripcion;
            comentariosTextBox.Text = grupo.Comentarios;

            //Cargar el detalle al Grid
            detalleDataGridView.DataSource = grupo.Detalle;

            //Ocultar columnas
            detalleDataGridView.Columns["Id"].Visible = false;
            detalleDataGridView.Columns["PersonaId"].Visible = false;
        }
        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (detalleDataGridView.Rows.Count > 0
                && detalleDataGridView.CurrentRow != null)
            {
                //convertir el grid en la lista
                List<GruposDetalle> detalle
                    = (List<GruposDetalle>)detalleDataGridView.DataSource;

                //remover la fila
                detalle.RemoveAt(detalleDataGridView.CurrentRow.Index);

                // Cargar el detalle al Grid
                detalleDataGridView.DataSource = null;
                detalleDataGridView.DataSource = detalle;
            }
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(comentariosTextBox.Text))
            {
                MyerrorProvider.SetError(comentariosTextBox,
                    "No debes dejar el Comentario vacio");
                HayErrores = true;
            }

            if (detalleDataGridView.RowCount == 0)
            {
                MyerrorProvider.SetError(detalleDataGridView,
                    "Es obligatorio seleccionar las personas");
                HayErrores = true;
            }

            return HayErrores;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;

            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }


        private void CiudadcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
