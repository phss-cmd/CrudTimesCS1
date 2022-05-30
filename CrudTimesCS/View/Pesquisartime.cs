using CrudTimesCS.Controller;
using CrudTimesCS.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace CrudTimesCS.View
{
    public partial class Pesquisartime : Form
    {
        public Pesquisartime()
        {
            InitializeComponent();
        }

        private void textBoxcodigopes_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Time.Codtimes = Convert.ToInt32(textBoxcodigopes.Text);

            if (textBoxcodigopes.Text == "")
            {
                MessageBox.Show("Digite um número");
                return;
            }

            var resposta = MessageBox.Show("Deseja excluir um time" + textBoxcodigopes.Text + "?",
            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (resposta == DialogResult.Yes)
            {
                Time.Codtimes = Convert.ToInt32(textBoxcodigopes.Text);

                ManipulaTimes manipulaTimes = new ManipulaTimes();
                manipulaTimes.deletarTimes();
            }
            else
            {
                textBox1.Text = string.Empty;
                textBoxtimeres.Text = String.Empty;
                textBoxfraseres.Text = string.Empty;
                textBoxcodigopes.Text = string.Empty;


            }


        }

        private void buttonpescod_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBoxcodigopes.Text == "")
                {
                    MessageBox.Show("Digite um Codigo Válido");
                    return;
                }
                else
                {
                    Time.Codtimes = Convert.ToInt32(textBoxcodigopes.Text);
                }

                Time.Codtimes = Convert.ToInt32(textBoxcodigopes.Text);

                ManipulaTimes manipula = new ManipulaTimes();
                manipula.pesquisarcodigojogadores();


                textBoxcodigores.Text = Time.Codtimes.ToString();
                textBoxtimeres.Text = Time.Nometimes.ToString();
                textBoxfraseres.Text = Time.Frasetimes.ToString();
                MemoryStream ms = new MemoryStream((byte[])Time.Logotimes1);
                pictureBoxlogores.Image = null;


            }
            catch (Exception)
            {
                MessageBox.Show("Digite o código novamente");
                return;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonalterar_Click(object sender, EventArgs e)
        {
            if (textBoxcodigopes.Text == "")
            {
                MessageBox.Show("Digite o codigo valido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                textBoxcodigores.Text = Time.Codtimes.ToString();
                textBoxtimeres.Text = Time.Nometimes.ToString();
                textBoxfraseres.Text = Time.Frasetimes.ToString();
                MemoryStream ms = new MemoryStream((byte[])Time.Logotimes1);
                pictureBoxlogores.Image = null;
                return;

            }

            var resposta = MessageBox.Show("deseja fazer alteração no time de codigo" + textBoxcodigopes);

            if (resposta == DialogResult.Yes)
            {
                Time.Codtimes = Convert.ToInt32(textBoxcodigopes.Text);
                Time.Nometimes = textBoxtimeres.Text;
                Time.Frasetimes = textBoxfraseres.Text;
                //  Time.Logotimes1 = ;

                ManipulaTimes manipulaTimes = new ManipulaTimes();
                manipulaTimes.alterarTimes();
            }
        }

        private void btnAlterarImagem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Escolha seu logo("")
        }
    }
}
