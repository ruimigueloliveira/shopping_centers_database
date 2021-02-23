using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Interface
{
    class FuncoesCentros
    {
        Form1 myForm;

        FuncoesAux funcoesAux;
        public FuncoesCentros(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
            
        }

        public int getIDCentro()
        {
            if (myForm.CN.State == System.Data.ConnectionState.Closed)
                myForm.CN.Open();
            var cmd = new SqlCommand("dbo.fnGetNextIDCentro", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            cmd.ExecuteNonQuery();
            int retVal = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            myForm.CN.Close();
            return retVal;
        }

        public void getTabelaCentros()
        {
            if (myForm.CN.State == System.Data.ConnectionState.Closed)
                myForm.CN.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT * FROM centro_comercial.centro", myForm.CN);
            SqlDataReader myReader = sqlcmd.ExecuteReader();
            myForm.listBox1.Items.Clear();
            funcoesAux.ReadOnly();
            ReadOnlyCentro();
            while (myReader.Read())
            {
                Centro centro = new Centro();
                centro.ID = myReader["ID"].ToString();
                centro.Nome = myReader["Nome"].ToString();
                centro.Localizacao = myReader["Localizacao"].ToString();
                centro.Num_lojas = myReader["Num_lojas"].ToString();
                centro.Area_total = myReader["Area_total"].ToString();
                myForm.listBox1.Items.Add(centro);
            }
            myForm.CN.Close();

            myForm.CN.Open();
            foreach (Centro c in myForm.listBox1.Items)
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.fnGetNumLojas(@ID_centro)", myForm.CN);
                cmd.Parameters.AddWithValue("@ID_centro", c.ID);
                c.Num_lojas = cmd.ExecuteScalar().ToString();
            }
            myForm.CN.Close();
            myForm.centroAtual = 1;
        }

        public void listBoxCentroAlterada()
        {
            if (myForm.listBox1.SelectedIndex > -1)
            {
                myForm.centroAtual = myForm.listBox1.SelectedIndex + 1;
                funcoesAux.clearAllListBox();
                ClearItems();
                HideAll();
                funcoesAux.HideButtons();
                ResetAll();
                MostrarCentro();
                BtnVisibles();
                ShowEditRemBtn();
                funcoesAux.UnlockButtons();
            }
        }

        public void MostrarCentro(string id=null)
        {
            if (id != null)
            {
                myForm.centroAtual = -1;
                foreach (Centro c in myForm.listBox1.Items)
                {
                    myForm.centroAtual += 1;
                    if (c.ID == id)
                    {
                        myForm.listBox1.SelectedIndex = myForm.centroAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox1.Items.Count == 0 | myForm.centroAtual < 0)
                return;
            Centro centro = new Centro();
            centro = (Centro)myForm.listBox1.Items[myForm.centroAtual - 1];     // ID do centro começa em 1 (em vez de 0)
            myForm.textCentroID.Text = centro.ID;
            myForm.textCentroNome.Text = centro.Nome;
            myForm.textCentroLocalizacao.Text = centro.Localizacao;
            myForm.textCentroNumeroLojas.Text = centro.Num_lojas;
            myForm.textCentroArea.Text = centro.Area_total;
        }

        public void AddCentro()
        {
            myForm.CN.Open();

            Centro c = new Centro();

            c.Nome = myForm.textCentroNome.Text;
            c.Localizacao = myForm.textCentroLocalizacao.Text;
            c.Num_lojas = myForm.textCentroNumeroLojas.Text;
            c.Area_total = myForm.textCentroArea.Text;
            c.ID = myForm.textCentroID.Text;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO centro_comercial.centro (Nome, Localizacao, Num_lojas, Area_total, ID) " + "VALUES (@Nome, @Localizacao, @Num_lojas, @Area_total, @ID)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Localizacao", c.Localizacao);
            cmd.Parameters.AddWithValue("@Num_lojas", c.Num_lojas);
            cmd.Parameters.AddWithValue("@Area_total", c.Area_total);
            cmd.Parameters.AddWithValue("@ID", c.ID);

            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
                myForm.updateIDCentro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaCentros();
                MostrarCentro(c.ID);
            }
        }

        // Editar Centro
        public void EditCentro()
        {
            myForm.CN.Open();

            Centro c = new Centro();

            c.Nome = myForm.textCentroNome.Text;
            c.Localizacao = myForm.textCentroLocalizacao.Text;
            c.Num_lojas = myForm.textCentroNumeroLojas.Text;
            c.Area_total = myForm.textCentroArea.Text;
            c.ID = myForm.textCentroID.Text;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE centro_comercial.centro SET Nome = @Nome, Localizacao = @Localizacao, Num_lojas = @Num_lojas, Area_total = @Area_total WHERE ID = @ID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Localizacao", c.Localizacao);
            cmd.Parameters.AddWithValue("@Num_lojas", c.Num_lojas);
            cmd.Parameters.AddWithValue("@Area_total", c.Area_total);
            cmd.Parameters.AddWithValue("@ID", c.ID);
            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaCentros();
                MostrarCentro(c.ID);
            }
        }

        // Remove centro
        public void RemoveCentro()
        {
            myForm.CN.Open();
            string id = (((Centro)myForm.listBox1.SelectedItem).ID);
            

            SqlCommand cmd = new SqlCommand("spDelCentro", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", id));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaCentros();
                MostrarCentro();
                funcoesAux.UnlockButtons();
                funcoesAux.ClearFields();
                funcoesAux.ReadOnly();
                funcoesAux.ShowAddBtn();
            }
        }

        public void ReadOnlyCentro()
        {
            myForm.textCentroID.ReadOnly = true;
            myForm.textCentroNome.ReadOnly = true;
            myForm.textCentroLocalizacao.ReadOnly = true;
            myForm.textCentroNumeroLojas.ReadOnly = true;
            myForm.textCentroArea.ReadOnly = true;
        }

        public void EnableWriteCentro()
        {
            myForm.textCentroNome.ReadOnly = false;
            myForm.textCentroLocalizacao.ReadOnly = false;
            myForm.textCentroArea.ReadOnly = false;
        }

        public void ClearFieldsCentro()
        {
            myForm.textCentroArea.Text = "";
            myForm.textCentroID.Text = "";
            myForm.textCentroLocalizacao.Text = "";
            myForm.textCentroNome.Text = "";
            myForm.textCentroNumeroLojas.Text = "";
        }

        public void DisableListBoxCentro()
        {
            myForm.listBox1.Enabled = false;
        }

        public void EnableListBoxCentro()
        {
            myForm.listBox1.Enabled = true;
        }

        public void UnselectListBoxCentro()
        {
            myForm.listBox1.SelectedIndex = -1;
        }

        public void ShowConfCancBtn()
        {
            myForm.btnAddCentro.Visible = false;
            myForm.btnEditCentro.Visible = false;
            myForm.btnRemoveCentro.Visible = false;
            myForm.btnConfirmCentro.Visible = true;
            myForm.btnCancelarCentro.Visible = true;
        }

        public void ShowAddBtn()
        {
            myForm.btnAddCentro.Visible = true;
            myForm.btnEditCentro.Visible = false;
            myForm.btnRemoveCentro.Visible = false;
            myForm.btnConfirmCentro.Visible = false;
            myForm.btnCancelarCentro.Visible = false;
        }

        public void ShowEditRemBtn()
        {
            myForm.btnAddCentro.Visible = true;
            myForm.btnEditCentro.Visible = true;
            myForm.btnRemoveCentro.Visible = true;
            myForm.btnConfirmCentro.Visible = false;
            myForm.btnCancelarCentro.Visible = false;
        }

        public void ClearItems()
        {
            myForm.listBox2.Items.Clear();
            myForm.listBox3.Items.Clear();
            myForm.listBox4.Items.Clear();
            myForm.listBox5.Items.Clear();
            myForm.listBox6.Items.Clear();
            myForm.listBox7.Items.Clear();
            myForm.listBox8.Items.Clear();
        }

        public void BtnVisibles()
        {
            myForm.button1.Visible = true;
            myForm.button2.Visible = true;
            myForm.button3.Visible = true;
            myForm.button4.Visible = true;
            myForm.button5.Visible = true;
            myForm.button6.Visible = true;
            myForm.button7.Visible = true;
        }
        public void ResetAll()
        {
            myForm.lojas1.resetLojas();
            myForm.departamentos1.resetDepartamentos();
            myForm.prestadores1.resetPrestadores();
            myForm.eventos1.resetEventos();
            myForm.empresas1.resetEmpresas();
            myForm.funcionarios1.resetFuncionarios();
            myForm.resp_departamentos1.resetResponsavel();
        }

        public void HideAll()
        {
            myForm.lojas1.Hide();
            myForm.departamentos1.Hide();
            myForm.prestadores1.Hide();
            myForm.eventos1.Hide();
            myForm.empresas1.Hide();
            myForm.funcionarios1.Hide();
            myForm.resp_departamentos1.Hide();
        }
    }
}
