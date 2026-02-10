namespace posto_desktop.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBomba;
        private System.Windows.Forms.Button btnConsumo;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnBomba = new System.Windows.Forms.Button();
            this.btnConsumo = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.btnBomba.Location = new System.Drawing.Point(30, 20);
            this.btnBomba.Size = new System.Drawing.Size(220, 40);
            this.btnBomba.Text = "Cadastrar Bomba";
            this.btnBomba.Click += new System.EventHandler(this.btnBomba_Click);

            this.btnConsumo.Location = new System.Drawing.Point(30, 70);
            this.btnConsumo.Size = new System.Drawing.Size(220, 40);
            this.btnConsumo.Text = "Registrar Consumo";
            this.btnConsumo.Click += new System.EventHandler(this.btnConsumo_Click);

            this.btnSync.Location = new System.Drawing.Point(30, 120);
            this.btnSync.Size = new System.Drawing.Size(220, 40);
            this.btnSync.Text = "Sincronizar Agora";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);

            this.lblStatus.Location = new System.Drawing.Point(30, 175);
            this.lblStatus.Size = new System.Drawing.Size(220, 20);
            this.lblStatus.Text = "Status:";

            this.ClientSize = new System.Drawing.Size(290, 220);
            this.Controls.Add(this.btnBomba);
            this.Controls.Add(this.btnConsumo);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.lblStatus);
            this.Text = "Fuel Desktop";
            this.ResumeLayout(false);
        }
    }
}
