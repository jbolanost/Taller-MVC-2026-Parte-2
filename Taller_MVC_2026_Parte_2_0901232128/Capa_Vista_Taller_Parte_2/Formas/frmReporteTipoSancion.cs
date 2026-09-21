using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Taller_Parte_2;
using Capa_Controlador_Taller_Parte_2.Controlador;
using Microsoft.Reporting.WinForms;

namespace Capa_Vista_Taller_Parte_2.Formas
{
    public partial class frmReporteTipoSancion : Form
    {
        private ModeloTipoSanciones tipoSanciones = new ModeloTipoSanciones();
        public frmReporteTipoSancion()
        {
            InitializeComponent();
        }

        private void frmReporteTipoSancion_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource("ReporteTipoSanciones", tipoSanciones.GetAll());
            rvTipoSanciones.LocalReport.ReportEmbeddedResource = "Capa_Vista_Taller_Parte_2.Reportes.ReporteTipoSanciones.rdlc";
            rvTipoSanciones.LocalReport.DataSources.Clear();
            rvTipoSanciones.LocalReport.DataSources.Add(reportDataSource);

            this.rvTipoSanciones.RefreshReport();
        }
    }
}
