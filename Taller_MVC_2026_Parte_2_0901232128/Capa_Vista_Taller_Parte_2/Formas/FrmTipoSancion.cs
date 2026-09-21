using Capa_Controlador_Taller_Parte_2.Estados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Taller_Parte_2.Controlador;

namespace Capa_Vista_Taller_Parte_2.Formas
{
    public partial class FrmTipoSancion : Form
    {
        private ModeloTipoSanciones tipo_sancion = new ModeloTipoSanciones();
        public FrmTipoSancion()
        {
            InitializeComponent();
            panDatos.Enabled = false;
            CargarDatos();
        }
        private void listaTipoSancion()
        {
            try
            {
                dgvTipoSancion.DataSource = tipo_sancion.GetAll();
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void Reinicio()
        {
            panDatos.Enabled = false;
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            panDatos.Enabled = true;
            tipo_sancion.Estado = EstadoEntidad.Added;
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (dgvTipoSancion.SelectedRows.Count > 0)
            {
                tipo_sancion.Estado = EstadoEntidad.Deleted;
                tipo_sancion.id_tipo_sancion = Convert.ToInt32(dgvTipoSancion.CurrentRow.Cells[0].Value);
                string resultado = tipo_sancion.GrabarCambios();
                MessageBox.Show(resultado);
                listaTipoSancion();
            }
            else MessageBox.Show("Seleccione una fila");
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvTipoSancion.SelectedRows.Count > 0)
            {
                panDatos.Enabled = true;
                tipo_sancion.Estado = EstadoEntidad.Modified;
                tipo_sancion.id_tipo_sancion = Convert.ToInt32(dgvTipoSancion.CurrentRow.Cells[0].Value);
                txtNombre.Text = dgvTipoSancion.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = dgvTipoSancion.CurrentRow.Cells[2].Value.ToString();
            }
            else MessageBox.Show("Seleccione una fila");
        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            tipo_sancion.nombre_tipo = txtNombre.Text;
            tipo_sancion.descripcion = txtDescripcion.Text;
            bool valido = new Ayudas.ValidacionDatos(tipo_sancion).Validar();
            if (valido == true)
            {
                string resultado = tipo_sancion.GrabarCambios();
                MessageBox.Show(resultado);
                listaTipoSancion();
                Reinicio();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvTipoSancion.DataSource = tipo_sancion.FindbyId(txtBuscar.Text);
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgvTipoSancion.DataSource = tipo_sancion.FindbyId(txtBuscar.Text);
        }

        private void FrmTipoSancion_Load_1(object sender, EventArgs e)
        {
            listaTipoSancion();
        }

        void CargarDatos()
        {
            comboI1.llenarCombo("sancion", "id_tipo_sancion", "descripcion");

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteTipoSancion reporte = new frmReporteTipoSancion();
            reporte.Show();
        }
    }
}
