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
    public partial class ConsumoForm : Form
    {
        private readonly BombaRepository _bombaRepository = new BombaRepository();
        private readonly ConsumoRepository _consumoRepository = new ConsumoRepository();

        public ConsumoForm()
        {
            InitializeComponent();
            CarregarBombas();
        }

        private void CarregarBombas()
        {
            cmbBomba.DataSource = _bombaRepository.GetAll();
            cmbBomba.DisplayMember = "Numero";
            cmbBomba.ValueMember = "Uuid";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var consumo = new Consumo
            {
                Uuid = Guid.NewGuid(),
                BombaUuid = (Guid)cmbBomba.SelectedValue,
                Litros = decimal.Parse(txtLitros.Text),
                DataConsumo = DateTime.Now,
                Sincronizado = false
            };

            _bombaRepository.DebitarEstoque(consumo.BombaUuid, consumo.Litros);
            _consumoRepository.Save(consumo);

            MessageBox.Show("Consumo registrado!");
            Close();
        }
    }
}
