namespace Capa_Vista_Taller_Parte_2.Formas
{
    partial class frmReporteTipoSancion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rvTipoSanciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvTipoSanciones
            // 
            this.rvTipoSanciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvTipoSanciones.Location = new System.Drawing.Point(0, 0);
            this.rvTipoSanciones.Name = "rvTipoSanciones";
            this.rvTipoSanciones.ServerReport.BearerToken = null;
            this.rvTipoSanciones.Size = new System.Drawing.Size(800, 450);
            this.rvTipoSanciones.TabIndex = 0;
            // 
            // frmReporteTipoSancion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvTipoSanciones);
            this.Name = "frmReporteTipoSancion";
            this.Text = "frmReporteTipoSancion";
            this.Load += new System.EventHandler(this.frmReporteTipoSancion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvTipoSanciones;
    }
}