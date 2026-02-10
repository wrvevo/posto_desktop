namespace posto_desktop.UI
{
    partial class BombaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Button btnSalvar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.txtNumero.Location = new System.Drawing.Point(20, 20);
            this.txtNumero.PlaceholderText = "Número da bomba";

            this.txtEstoque.Location = new System.Drawing.Point(20, 60);
            this.txtEstoque.PlaceholderText = "Estoque em litros";

            this.btnSalvar.Location = new System.Drawing.Point(20, 110);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.ClientSize = new System.Drawing.Size(240, 160);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.btnSalvar);
            this.Text = "Cadastro de Bomba";
            this.ResumeLayout(false);
        }
    }
}