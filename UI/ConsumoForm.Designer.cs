namespace posto_desktop.UI
{
    partial class ConsumoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbBomba;
        private System.Windows.Forms.TextBox txtLitros;
        private System.Windows.Forms.Button btnRegistrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbBomba = new System.Windows.Forms.ComboBox();
            this.txtLitros = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.cmbBomba.Location = new System.Drawing.Point(20, 20);
            this.cmbBomba.Width = 200;

            this.txtLitros.Location = new System.Drawing.Point(20, 60);
            this.txtLitros.PlaceholderText = "Litros consumidos";

            this.btnRegistrar.Location = new System.Drawing.Point(20, 110);
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            this.ClientSize = new System.Drawing.Size(250, 160);
            this.Controls.Add(this.cmbBomba);
            this.Controls.Add(this.txtLitros);
            this.Controls.Add(this.btnRegistrar);
            this.Text = "Registro de Consumo";
            this.ResumeLayout(false);
        }
    }
}