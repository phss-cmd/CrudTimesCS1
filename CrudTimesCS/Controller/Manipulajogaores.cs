
using System.Data.SqlClient;
using CrudTimesCS.model;
using System.Windows.Forms;
using System.Data;
using System;
using CrudTimesCS.controler;

namespace CrudTimesCS.Controller
{
    class Manipulajogaores
    {
        public void cadastrarjogador()
        {

            SqlConnection cnj = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmdj = new SqlCommand("pInserirjogadores", cnj);
            cmdj.CommandType = CommandType.StoredProcedure;


            try
            {

                cmdj.Parameters.AddWithValue("nomejogadores", Jogadores.NomeJogadores);
                cmdj.Parameters.AddWithValue("emailjogadores", Jogadores.EmailJogadores);
                cmdj.Parameters.AddWithValue("fonejogadores", Jogadores.FoneJogadores);

                SqlParameter nvj = cmdj.Parameters.Add("@idjogadores", SqlDbType.Int);
                nvj.Direction = ParameterDirection.Output;

                cnj.Open();
                cmdj.ExecuteNonQuery();

                var resposta = MessageBox.Show("Seu cadastro efetuado com sucesso, deseja executar um novo cadastro ?", "Parabéns", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resposta == DialogResult.Yes)
                {

                    Jogadores.Retorno = "sim";
                    return;

                }
                else
                {

                    Jogadores.Retorno = "não";
                    return;

                }

            }

            catch (Exception)
            {
                throw;
            }


        }

        public void pesquisarjogadores()
        {
            SqlConnection cn = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pBuscarcodigojogadores", cn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                cmd.Parameters.AddWithValue("@idjogadores", Jogadores.CodJogadores);
                cn.Open();

                var arrayDados = cmd.ExecuteReader();


                if (arrayDados.Read())
                {

                    Jogadores.CodJogadores = Convert.ToInt32(arrayDados["idjogadores"]);
                    Jogadores.NomeJogadores = arrayDados["nomejogadores"].ToString();
                    Jogadores.EmailJogadores = arrayDados["emailjogadores"].ToString();
                    Jogadores.FoneJogadores = arrayDados["fonejogadores"].ToString();
                    Jogadores.Retorno = "sim";
                }
                else
                {
                    MessageBox.Show("Código não é Válido", "Atencão!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Jogadores.Retorno = "Não";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void deletarjogadores()
        {
            SqlConnection cn = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pDeletarJogadores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@CodJogadores", Jogadores.CodJogadores);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Jogador excluído com sucesso",
                    "Exclução", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("O Jogador não pode ser excluído",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

        }
        public void alterarJogadores()
        {
            SqlConnection cn = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pAlterarJogadores", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@CodJogadores", Jogadores.CodJogadores);
                cmd.Parameters.AddWithValue("@NomeJogadores", Jogadores.NomeJogadores);
                cmd.Parameters.AddWithValue("@FoneJogadores", Jogadores.FoneJogadores);


                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Jogador alterado com sucesso", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception)
            {
                MessageBox.Show("O Jogador não foi Alterado",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
    }
}

