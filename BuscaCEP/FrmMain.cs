using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios;
namespace BuscaCEP
{
    public partial class fmrMain : Form
    {
        public fmrMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a Consulta ? ", "Encerrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            Application.Exit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCEP.Text))
                MessageBox.Show("O Campo CEP deve ser Preenchido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {

                try
                {
                    CorreiosApi correios = new CorreiosApi();

                    var retorno = correios.consultaCEP(txtCEP.Text);

                    if (retorno is null)
                    {
                        return;
                    }

                    txtEndereco.Text = retorno.end;
                    txtBairro.Text = retorno.bairro;
                    txtCidade.Text = retorno.cidade;
                    txtEstado.Text = retorno.uf;

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao realizar Consulta" + erro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
    }
}
