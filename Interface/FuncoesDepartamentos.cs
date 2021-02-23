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
    class FuncoesDepartamentos
    {
        Form1 myForm;
        FuncoesAux funcoesAux;

        public FuncoesDepartamentos(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
        }

        public int getNumDep()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("SELECT dbo.fnGetNextNumDep(@ID_centro)", myForm.CN);
            cmd.Parameters.AddWithValue("@ID_centro", myForm.textCentroID.Text);
            int retVal = int.Parse(cmd.ExecuteScalar().ToString());
            myForm.CN.Close();
            return retVal;   
        }

        public void getTabelaDepartamentos()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spDepartamentos", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox3.Items.Clear();
            try
            {
                while (rdr.Read())
                {
                    Departamento departamento = new Departamento();
                    departamento.ID = rdr["ID"].ToString();
                    departamento.Nome = rdr["Nome"].ToString();
                    departamento.Nome_responsavel = rdr["Primeiro_nome"].ToString() + " " + rdr["Ultimo_nome"].ToString();
                    departamento.Num_responsavel = rdr["Num_responsavel"].ToString();
                    myForm.listBox3.Items.Add(departamento);
                }
                myForm.departamentoAtual = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                rdr.Close();
                setComboBoxResponsaveis();
            }


        }

        public void listBoxDepartamentoAlterada()
        {
            myForm.departamentoAtual = myForm.listBox3.SelectedIndex;
            MostrarDepartamento();
            myForm.btnEdit.Visible = true;
            myForm.btnRemove.Visible = true;
            myForm.btnSearch.Visible = false;
        }

        public void MostrarDepartamento(string dep_id = null)
        {
            if (dep_id != null)
            {
                myForm.departamentoAtual = -1;
                foreach (Departamento d in myForm.listBox3.Items)
                {
                    myForm.departamentoAtual += 1;
                    if (d.ID == dep_id)
                    {
                        myForm.listBox3.SelectedIndex = myForm.departamentoAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox3.Items.Count == 0 | myForm.departamentoAtual < 0)
                return;
            Departamento departamento = new Departamento();
            departamento = (Departamento)myForm.listBox3.Items[myForm.departamentoAtual];
            myForm.departamentos1.setTextID(departamento.ID);
            myForm.departamentos1.setTextNome(departamento.Nome);
            myForm.departamentos1.setTextNome_responsavel(departamento.Nome_responsavel);
            myForm.departamentos1.setComboBoxNome_responsavel(departamento.Num_responsavel + " " + departamento.Nome_responsavel);
        }

        // Adicionar departamento
        public void AddDepartamento()
        {
            if (myForm.departamentos1.comboBoxDepartamentosAdministradores.SelectedIndex > -1)
            {
                myForm.CN.Open();

                Departamento dep = new Departamento();
                dep.ID = myForm.departamentos1.getNumDep().ToString();
                dep.Nome = myForm.departamentos1.getTextNome();
                dep.Num_responsavel = myForm.departamentos1.getTextNum_responsavel();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT centro_comercial.departamento (ID, Nome, Num_responsavel) VALUES (@ID, @Nome, @Num_responsavel)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", dep.ID);
                cmd.Parameters.AddWithValue("@Nome", dep.Nome);
                cmd.Parameters.AddWithValue("@Num_responsavel", dep.Num_responsavel);
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
                    getTabelaDepartamentos();
                    MostrarDepartamento(dep.ID);
                }
            }
            else
            {
                MessageBox.Show("Um departamento necessita de um administrador associado");
                myForm.departamentos1.readOnlyDepartamentos();
                getTabelaDepartamentos();
            }
            
        }

        // Editar departamento
        public void EditDepartamento()
        {
            if (myForm.departamentos1.comboBoxDepartamentosAdministradores.SelectedIndex > -1)
            {
                myForm.CN.Open();

                Departamento dep = new Departamento();
                dep.ID = myForm.departamentos1.getTextID();
                dep.Nome = myForm.departamentos1.getTextNome();
                dep.Num_responsavel = myForm.departamentos1.getTextNum_responsavel();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE centro_comercial.departamento SET Nome = @Nome, Num_responsavel = @Num_responsavel WHERE ID = @ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", dep.ID);
                cmd.Parameters.AddWithValue("@Nome", dep.Nome);
                cmd.Parameters.AddWithValue("@Num_responsavel", dep.Num_responsavel);
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
                    getTabelaDepartamentos();
                    MostrarDepartamento(dep.ID);
                }
            }
            else
            {
                MessageBox.Show("Um departamento necessita de um administrador associado");
                myForm.departamentos1.readOnlyDepartamentos();
                getTabelaDepartamentos();
            }

        }

        // Remover departamento
        public void RemoveDepartamento(string id)
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spDelDepartamento", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            cmd.Parameters.Add(new SqlParameter("@ID_departamento", id));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Não pode remover nenhum dos 3 departamentos essenciais (marketing, comercial, operaçoes).\n");
            }
            finally
            {
                myForm.CN.Close();
                getTabelaDepartamentos();
                MostrarDepartamento();
                funcoesAux.UnlockButtons();
                funcoesAux.ClearFields();
                funcoesAux.ReadOnly();
                funcoesAux.ShowAddBtn();
            }
        }

        public void setComboBoxResponsaveis()
        {
            myForm.CN.Open();
            myForm.departamentos1.comboBoxDepartamentosAdministradores.Items.Clear();
            myForm.departamentos1.comboBoxDepartamentosAdministradores.Text = "";
            SqlCommand cmd = new SqlCommand("spDistinctAdmin", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    string resp = rdr["Num_func"].ToString() + " " + rdr["Primeiro_nome"] + " " + rdr["Ultimo_nome"];
                    myForm.departamentos1.comboBoxDepartamentosAdministradores.Items.Add(resp);
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

        public void SearchDepartamento()
        {
            // Procurar pelo ID do departamento
            string id = myForm.departamentos1.getTextID();
            MostrarDepartamento(id);
        }
    }
}
