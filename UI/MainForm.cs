using posto_desktop.Infrastructure.Sync;
using posto_desktop.UI;
using System;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms;

namespace posto_desktop.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AtualizarStatus("Offline", Color.Red);
        }

        private void btnBomba_Click(object sender, EventArgs e)
        {
            new BombaForm().ShowDialog();
        }

        private void btnConsumo_Click(object sender, EventArgs e)
        {
            new ConsumoForm().ShowDialog();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            AtualizarStatus("Sincronizando...", Color.Orange);

            try
            {
                var agent = new SyncAgent();
                int total = await agent.SincronizarAsync();

                AtualizarStatus($"Sincronizado ({total})", Color.Green);
            }
            catch (Exception ex)
            {
                AtualizarStatus("Erro na sincronização", Color.Red);
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSync.Enabled = true;
            }
        }

        private void AtualizarStatus(string texto, Color cor)
        {
            lblStatus.Text = $"Status: {texto}";
            lblStatus.ForeColor = cor;
        }
    }
}

