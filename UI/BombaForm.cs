using posto_desktop.Domain;
using posto_desktop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace posto_desktop.UI
{
    public partial class BombaForm : Form
    {
        private readonly BombaRepository _repository = new BombaRepository();

        public BombaForm()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var bomba = new Bomba
            {
                Uuid = Guid.NewGuid(),
                Numero = int.Parse(txtNumero.Text),
                EstoqueLitros = decimal.Parse(txtEstoque.Text)
            };

            _repository.Save(bomba);

            MessageBox.Show("Bomba cadastrada com sucesso!");
            Close();
        }
    }
}
