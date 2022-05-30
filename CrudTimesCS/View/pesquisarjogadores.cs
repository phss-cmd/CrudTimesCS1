using CrudTimesCS.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudTimesCS.Controller;

namespace CrudTimesCS.View
{
    public partial class pesquisarjogadores : Form
    {
        public pesquisarjogadores()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonbusj_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(textBoxpesj.Text == "")
                {
                    MessageBox.Show("Digite um código válido");
                    return;
                }
                else
                {
                    
                    Jogadores.CodJogadores = Convert.ToInt32(textBoxpesj.Text);
                    
                }

               

                Manipulajogaores manipula = new Manipulajogaores();
                manipula.pesquisarjogadores();

                textBoxcodresj.Text = Jogadores.CodJogadores.ToString();
                textBoxnomeresj.Text = Jogadores.NomeJogadores.ToString();
                textBoxemailresj.Text = Jogadores.EmailJogadores.ToString();
                textBoxfoneresj.Text = Jogadores.FoneJogadores.ToString();


            }

            catch (Exception)
            {
                MessageBox.Show("Digite o código novamente");
                return;
            }

        }
    }
}
