using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudTimesCS.model;
using CrudTimesCS.Controller;

namespace CrudTimesCS.View
{
    public partial class TelaCasdastrarJogadores : Form
    {
        public TelaCasdastrarJogadores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBoxnomejogador.Text =="" || textBoxemalijogador.Text =="" || textBoxfonejogador.Text=="")
            {

                MessageBox.Show("Digite todas as informações", "Atenção!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Jogadores.NomeJogadores = textBoxnomejogador.Text;
            Jogadores.EmailJogadores = textBoxemalijogador.Text;
            Jogadores.FoneJogadores = textBoxfonejogador.Text;

            Manipulajogaores manipulajogaores = new Manipulajogaores();
            manipulajogaores.cadastrarjogador();

            if(Jogadores.Retorno == "Sim")
            {
                textBoxemalijogador.Text = string.Empty;
                textBoxnomejogador.Text = string.Empty;
                textBoxfonejogador.Text = string.Empty;
                return;
            }
            else
            {
                fecharcadastro();
                return;
            }

        }

        public void abrircadastro()
        {
            this.ShowDialog();
        }

        public void fecharcadastro()
        {
            this.Close();
        }

    }

}
