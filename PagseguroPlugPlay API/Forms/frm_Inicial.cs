using System;
using System.Windows.Forms;

namespace PagseguroPlugPlay_API.Forms
{
    public partial class frm_Inicial : Form
    {
        public static int tipoPagamento;
        public static int ConfirmaPagamento;
        public static int vlTotal = 101;

        public frm_Inicial()
        {
            InitializeComponent();
        }

        private void btnEfetuarCompra_Click(object sender, EventArgs e)
        {
            tipoPagamento = 0;
            ConfirmaPagamento = 0;

            if (txtValorCompra.Text.Contains(","))
            {
                vlTotal = (int)Convert.ToDouble(txtValorCompra.Text.Replace(',', '.'));
            }
            else
            {
                vlTotal = Convert.ToInt32(txtValorCompra.Text) * 100;
            }

            try
            {
                if (chkCredito.Checked == true)
                {
                    tipoPagamento = 1;
                }
                else if (chkDebito.Checked == true)
                {
                    tipoPagamento = 2;
                }

                frm_Pagamento frmPagamento = new frm_Pagamento();
                frmPagamento.ShowDialog(this);
                frmPagamento.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Erro ao efetuar compra: \n\n{exception}");
            }
        }

        private void chkCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCredito.Checked == true)
            {
                chkDebito.Checked = false;
            }
        }

        private void chkDebito_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDebito.Checked == true)
            {
                chkCredito.Checked = false;
            }
        }

        private void btnEstornarCompra_Click(object sender, EventArgs e)
        {
            tipoPagamento = 0;

            try
            {
                frm_Pagamento frmPagamento = new frm_Pagamento();
                frmPagamento.ShowDialog(this);
                frmPagamento.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Erro ao estornar compra: \n\n{exception}");
            }
        }
    }
}