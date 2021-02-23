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
    class FuncoesLojas
    {
        Form1 myForm;
        FuncoesAux funcoesAux;
        public FuncoesLojas(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
        }

        public int getNumLoja()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("SELECT dbo.fnGetNextNumLoja(@ID_centro)", myForm.CN);
            cmd.Parameters.AddWithValue("@ID_centro", myForm.textCentroID.Text);
            int retVal = int.Parse(cmd.ExecuteScalar().ToString());
            myForm.CN.Close();
            return retVal;
        }

        public void getTabelaLojas()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spLojas", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox2.Items.Clear();
            try
            {
                while (rdr.Read())
                {
                    Loja loja = new Loja();
                    loja.Contacto = rdr["Contacto"].ToString();
                    loja.Nome_comercial = rdr["Nome_comercial"].ToString();
                    loja.Renda = rdr["Renda"].ToString();
                    loja.Num_loja = rdr["Num_loja"].ToString();
                    loja.Tipo = rdr["Tipo"].ToString();
                    loja.ID_centro = rdr["ID_centro"].ToString();
                    loja.Area = rdr["Area"].ToString();
                    loja.empresa = new Empresa(rdr["NIF_empresa"].ToString(), rdr["Nome"].ToString());
                    loja.Nome_gerente = rdr["Primeiro_nome"].ToString() + " " + rdr["Ultimo_nome"].ToString();
                    loja.Num_gerente = rdr["Num_gerente"].ToString();
                    myForm.listBox2.Items.Add(loja);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                rdr.Close();
                myForm.CN.Close();
                setComboBoxEmpresas();
            }
        }

        public void listBoxLojaAlterada()
        {
            myForm.lojaAtual = myForm.listBox2.SelectedIndex;
            myForm.lojas1.listBox1.Items.Clear();
            MostrarLoja();
            funcoesAux.ShowButtons();
        }

        public void MostrarLoja(string num_loja=null)
        {
            if (num_loja != null)
            {
                myForm.lojaAtual = -1;
                foreach (Loja l in myForm.listBox2.Items)
                {
                    myForm.lojaAtual += 1;
                    if (l.Num_loja == num_loja)
                    {
                        myForm.listBox2.SelectedIndex = myForm.lojaAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox2.Items.Count == 0 | myForm.lojaAtual < 0)
                return;
            Loja loja = new Loja();
            loja = (Loja)myForm.listBox2.Items[myForm.lojaAtual];
            myForm.lojas1.setTextContacto(loja.Contacto);
            myForm.lojas1.setTextNome_comercial(loja.Nome_comercial);
            myForm.lojas1.setTextRenda(loja.Renda);
            myForm.lojas1.setTextNumLoja(loja.Num_loja);
            myForm.lojas1.setTextNomeEmpresa(loja.empresa.Nome);
            myForm.lojas1.setTextTipo(loja.Tipo);
            myForm.lojas1.setTextArea(loja.Area);
            myForm.lojas1.setTextNomeGerente(loja.Nome_gerente);
            myForm.lojas1.setTextNIFEmpresa(loja.empresa.NIF + " " + loja.empresa.Nome);
            myForm.lojas1.setTextNumeroGerente(loja.Num_gerente);

            SqlCommand sqlcmd3 = new SqlCommand("select * from centro_comercial.funcionario_loja join centro_comercial.pessoa on centro_comercial.pessoa.NIF = centro_comercial.funcionario_loja.NIF where Numero_loja = " + myForm.lojas1.getTextNumLoja(), myForm.CN);
            
            myForm.CN.Open();
            setListBoxFuncionarios(loja.Num_loja);
            myForm.CN.Close();
        }

        // Adicionar loja
        public void AddLoja()
        {
            if (myForm.lojas1.comboBoxEmpresas.SelectedIndex > -1)
            {
                myForm.CN.Open();

                Loja l = new Loja();
                l.Contacto = myForm.lojas1.getTextContacto();
                l.Nome_comercial = myForm.lojas1.getTextNome();
                l.Renda = myForm.lojas1.getTextRenda();
                l.Num_loja = myForm.lojas1.getNumLoja().ToString();
                l.Tipo = myForm.lojas1.getTextTipo();
                l.Area = myForm.lojas1.getTextArea();
                l.empresa = new Empresa(myForm.lojas1.getTextNIFEmpresa(), myForm.lojas1.getTextNomeEmpresa());
                l.empresa.NIF = myForm.lojas1.getTextNIFEmpresa();
                l.Num_gerente = myForm.lojas1.getTextNumGerente();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO centro_comercial.loja (Contacto, Nome_comercial, Renda, Num_loja, NIF_empresa, Tipo, ID_centro, Area, Num_gerente) " + "VALUES (@Contacto, @Nome_comercial, @Renda, @Num_loja, @NIF_empresa, @Tipo, @ID_centro, @Area, @Num_gerente) ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Contacto", l.Contacto);
                cmd.Parameters.AddWithValue("@Nome_comercial", l.Nome_comercial);
                cmd.Parameters.AddWithValue("@Renda", l.Renda);
                cmd.Parameters.AddWithValue("@Num_loja", l.Num_loja);
                cmd.Parameters.AddWithValue("@NIF_empresa", l.empresa.NIF);
                cmd.Parameters.AddWithValue("@Tipo", l.Tipo);
                cmd.Parameters.AddWithValue("@ID_centro", myForm.textCentroID.Text);
                cmd.Parameters.AddWithValue("@Area", l.Area);
                cmd.Parameters.AddWithValue("@Num_gerente", l.Num_gerente);

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
                    getTabelaLojas();
                    MostrarLoja(l.Num_loja);
                }
            }
            else
            {
                MessageBox.Show("Uma loja necessita de uma empresa associada");
                myForm.lojas1.readOnlyLojas();
                getTabelaLojas();
            }

        }

        // Editar loja
        public void EditLoja()
        {
            if (myForm.lojas1.comboBoxEmpresas.SelectedIndex > -1)
            {
                myForm.CN.Open();
                Loja l = new Loja();

                if (!existeFuncionarioNaLoja(myForm.lojas1.getTextNumGerente()))
                {
                    MessageBox.Show("ERRO: ID do gerente inserido nao existe nesta loja");
                    myForm.CN.Close();
                    getTabelaLojas();
                    MostrarLoja(l.Num_loja);
                }
                else
                {
                    l.Contacto = myForm.lojas1.getTextContacto();
                    l.Nome_comercial = myForm.lojas1.getTextNome();
                    l.Renda = myForm.lojas1.getTextRenda();
                    l.Num_loja = myForm.lojas1.getTextNumLoja();
                    l.Tipo = myForm.lojas1.getTextTipo();
                    l.Area = myForm.lojas1.getTextArea();
                    l.Num_gerente = myForm.lojas1.getTextNumGerente();
                    l.empresa = new Empresa(myForm.lojas1.getTextNIFEmpresa(), myForm.lojas1.getTextNomeEmpresa());

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE centro_comercial.loja SET Contacto = @Contacto, Nome_comercial = @Nome_comercial, Renda = @Renda, Tipo = @Tipo, Area = @Area, Num_gerente = @Num_gerente, NIF_empresa = @NIF_empresa WHERE Num_loja = @Num_loja";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Contacto", l.Contacto);
                    cmd.Parameters.AddWithValue("@Nome_comercial", l.Nome_comercial);
                    cmd.Parameters.AddWithValue("@Renda", l.Renda);
                    cmd.Parameters.AddWithValue("@Num_loja", l.Num_loja);
                    cmd.Parameters.AddWithValue("@Tipo", l.Tipo);
                    cmd.Parameters.AddWithValue("@Area", l.Area);
                    cmd.Parameters.AddWithValue("@Num_gerente", l.Num_gerente);
                    cmd.Parameters.AddWithValue("@NIF_empresa", l.empresa.NIF);
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
                        getTabelaLojas();
                        MostrarLoja(l.Num_loja);
                    }
                }
            }
            else
            {
                MessageBox.Show("Uma loja necessita de uma empresa associada");
                myForm.lojas1.readOnlyLojas();
                getTabelaLojas();
            }
        }

        // Remover loja
        public void RemoveLoja()
        {
            myForm.CN.Open();
            string num = (((Loja)myForm.listBox2.SelectedItem).Num_loja);      // chave primaria
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE centro_comercial.loja WHERE Num_loja=@Num_loja;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Num_loja", num);
            cmd.Connection = myForm.CN;
            try
            {
                RemoveFuncionariosLojas(num);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaLojas();
                MostrarLoja();
                funcoesAux.ClearFields();
            }
        }

        // Remover Funcionarios de todas as lojas da empresas
        public void RemoveFuncionariosLojas(String Num_loja)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete centro_comercial.funcionario_loja where Numero_loja = @Num_loja;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Num_loja", Num_loja);
            cmd.Connection = myForm.CN;
            cmd.ExecuteNonQuery();
        }

        public void SearchLoja()
        {
            // Procurar pelo Numero da loja
            string num_loja = myForm.lojas1.getTextNumLoja();
            MostrarLoja(num_loja);
        }

        public void setListBoxFuncionarios(string num_loja)
        {
            myForm.lojas1.listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("spFuncLojaList", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@num_loja", num_loja));
            SqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while(rdr.Read())
                {
                    myForm.lojas1.listBox1.Items.Add(rdr["Num_func"].ToString() + " " + rdr["Primeiro_nome"] + " " + rdr["Ultimo_nome"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                rdr.Close();
            }
        }

        public void setComboBoxEmpresas()
        {
            myForm.CN.Open();
            myForm.lojas1.comboBoxEmpresas.Items.Clear();
            myForm.lojas1.comboBoxEmpresas.Text = "";
            SqlCommand cmd = new SqlCommand("spEmpresas", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    myForm.lojas1.comboBoxEmpresas.Items.Add(rdr["NIF"].ToString() + " " + rdr["Nome"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                rdr.Close();
                myForm.CN.Close();
            }
        }

        public Boolean existeFuncionarioNaLoja(String numGerente)
        {
            string[] words;

            foreach (String f in myForm.lojas1.listBox1.Items)
            {
                words = f.Split(' ');
                if (words[0].Equals(numGerente))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
