using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Interface
{
    class FuncoesFuncionarios
    {
        Form1 myForm;
        FuncoesAux funcoesAux;

        public FuncoesFuncionarios(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
        }

        public int getNumFuncionarios()
        {
            myForm.CN.Open();
            var cmd = new SqlCommand("dbo.fnGetNextNumFunc", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            cmd.ExecuteNonQuery();
            int retVal = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            myForm.CN.Close();
            return retVal;
        }

        public void getTabelaFuncionarios()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spFuncionarios", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox7.Items.Clear();

            try
            {
                while (rdr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.NIF = rdr["NIF"].ToString();
                    funcionario.Num_func = rdr["Num_func"].ToString();
                    funcionario.Contacto = rdr["Contacto"].ToString();
                    funcionario.Primeiro_nome = rdr["Primeiro_nome"].ToString();
                    funcionario.Ultimo_nome = rdr["Ultimo_nome"].ToString();
                    funcionario.Salario = rdr["Salario"].ToString();
                    funcionario.Horas_semanais = rdr["Horas_semanais"].ToString();
                    funcionario.Data_entrada = rdr["Data_entrada"].ToString();
                    funcionario.Nome_loja = rdr["Nome_comercial"].ToString();
                    funcionario.Numero_loja = rdr["Numero_loja"].ToString();
                    funcionario.Sexo = rdr["Sexo"].ToString();
                    myForm.listBox7.Items.Add(funcionario);
                }
                myForm.funcionarioAtual = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                rdr.Close();
                myForm.CN.Close();
                setComboBoxLojas();
            }
        }

        public void listBoxFuncionarioAlterada()
        {
            myForm.funcionarioAtual = myForm.listBox7.SelectedIndex;
            MostrarFuncionario();
            funcoesAux.ShowButtons();
        }

        public void MostrarFuncionario(string nif = null)
        {
            if (nif != null)
            {
                myForm.funcionarioAtual = -1;
                foreach (Funcionario f in myForm.listBox7.Items)
                {
                    myForm.funcionarioAtual += 1;
                    if (f.NIF == nif)
                    {
                        myForm.listBox7.SelectedIndex = myForm.funcionarioAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox7.Items.Count == 0 | myForm.funcionarioAtual < 0)
                return;
            Funcionario funcionario = new Funcionario();
            funcionario = (Funcionario)myForm.listBox7.Items[myForm.funcionarioAtual];
            myForm.funcionarios1.setTextNIF(funcionario.NIF);
            myForm.funcionarios1.setTextNumeroFunc(funcionario.Num_func);
            myForm.funcionarios1.setTextContacto(funcionario.Contacto);
            myForm.funcionarios1.setTextHorasSemanais(funcionario.Horas_semanais);
            myForm.funcionarios1.setTextDataEntrada(funcionario.Data_entrada);
            myForm.funcionarios1.setTextNomeLoja(funcionario.Nome_loja);
            myForm.funcionarios1.setTextPrimeiroNome(funcionario.Primeiro_nome);
            myForm.funcionarios1.setTextUltimoNome(funcionario.Ultimo_nome);
            myForm.funcionarios1.setTextSalario(funcionario.Salario);
            myForm.funcionarios1.setTextNumLoja(funcionario.Numero_loja + " " + funcionario.Nome_loja);
            myForm.funcionarios1.setTextSexo(funcionario.Sexo);
        }

        // Adicionar funcionarios
        public void AddFuncionarios()
        {
            if (myForm.funcionarios1.comboBoxLojas.SelectedIndex > -1)
            {
                myForm.CN.Open();

                Funcionario func = new Funcionario();
                func.NIF = myForm.funcionarios1.getTextNIF();
                func.Num_func = myForm.funcionarios1.getNumFunc().ToString();
                func.Contacto = myForm.funcionarios1.getTextContacto();
                func.Primeiro_nome = myForm.funcionarios1.getTextPrimeiroNome();
                func.Ultimo_nome = myForm.funcionarios1.getTextUltimoNome();
                func.Salario = myForm.funcionarios1.getTextSalario();
                func.Horas_semanais = myForm.funcionarios1.getTextHorasSemanais();
                func.Data_entrada = myForm.funcionarios1.getTextDataEntrada();
                func.Nome_loja = myForm.funcionarios1.getTextNomeLoja();
                func.Sexo = myForm.funcionarios1.getTextSexo();
                func.Numero_loja = myForm.funcionarios1.getTextNumLoja();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BEGIN TRANSACTION; INSERT centro_comercial.pessoa(Primeiro_nome, Ultimo_nome, Sexo, Contacto, NIF) VALUES(@Primeiro_nome, @Ultimo_nome, @Sexo, @Contacto, @NIF)" +
                    "INSERT centro_comercial.funcionario_loja (NIF, Data_entrada, Salario, Horas_semanais, Numero_loja, Num_func) VALUES (@NIF, @Data_entrada, @Salario, @Horas_semanais, @Numero_loja, @Num_func); COMMIT;";
                cmd.Parameters.Clear();
                
                try
                {
                    cmd.Parameters.AddWithValue("@Num_func", func.Num_func);
                    cmd.Parameters.AddWithValue("@NIF", func.NIF);
                    cmd.Parameters.AddWithValue("@Data_entrada", DateTime.Parse(func.Data_entrada));
                    cmd.Parameters.AddWithValue("@Salario", func.Salario);
                    cmd.Parameters.AddWithValue("@Numero_loja", func.Numero_loja);
                    cmd.Parameters.AddWithValue("@Horas_semanais", func.Horas_semanais);
                    cmd.Parameters.AddWithValue("@Primeiro_nome", func.Primeiro_nome);
                    cmd.Parameters.AddWithValue("@Ultimo_nome", func.Ultimo_nome);
                    cmd.Parameters.AddWithValue("@Sexo", func.Sexo);
                    cmd.Parameters.AddWithValue("@Contacto", func.Contacto);
                    cmd.Connection = myForm.CN;
                    cmd.ExecuteNonQuery();
                    myForm.funcionarios1.updateNumFunc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO: " + ex.Message);
                }
                finally
                {
                    myForm.CN.Close();
                    getTabelaFuncionarios();
                    MostrarFuncionario(func.NIF);
                }
            }
            else
            {
                MessageBox.Show("Um funcionário necessita de uma loja associada");
                myForm.funcionarios1.readOnlyFuncionarios();
                getTabelaFuncionarios();
            }
        }

        // Editar funcionarios
        public void EditFuncionarios()
        {
            if (myForm.funcionarios1.comboBoxLojas.SelectedIndex > -1)
            {
                myForm.CN.Open();

                Funcionario func = new Funcionario();
                func.NIF = myForm.funcionarios1.getTextNIF();
                func.Num_func = myForm.funcionarios1.getTextNumeroFunc();
                func.Contacto = myForm.funcionarios1.getTextContacto();
                func.Primeiro_nome = myForm.funcionarios1.getTextPrimeiroNome();
                func.Ultimo_nome = myForm.funcionarios1.getTextUltimoNome();
                func.Salario = myForm.funcionarios1.getTextSalario();
                func.Horas_semanais = myForm.funcionarios1.getTextHorasSemanais();
                func.Data_entrada = myForm.funcionarios1.getTextDataEntrada();
                func.Sexo = myForm.funcionarios1.getTextSexo();
                func.Numero_loja = myForm.funcionarios1.getTextNumLoja();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BEGIN TRANSACTION; UPDATE centro_comercial.funcionario_loja SET NIF = @NIF, Data_entrada = @Data_entrada, Salario = @Salario, Numero_loja = @Numero_loja, Horas_semanais = @Horas_semanais WHERE Num_func = @Num_func; " +
                    "UPDATE centro_comercial.pessoa SET Primeiro_nome = @Primeiro_nome, Ultimo_nome = @Ultimo_nome, Sexo = @Sexo, Contacto = @Contacto WHERE NIF = @NIF; COMMIT;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Num_func", func.Num_func);
                cmd.Parameters.AddWithValue("@NIF", func.NIF);
                cmd.Parameters.AddWithValue("@Data_entrada", DateTime.Parse(func.Data_entrada));
                cmd.Parameters.AddWithValue("@Salario", func.Salario);
                cmd.Parameters.AddWithValue("@Numero_loja", func.Numero_loja);
                cmd.Parameters.AddWithValue("@Horas_semanais", func.Horas_semanais);
                cmd.Parameters.AddWithValue("@Primeiro_nome", func.Primeiro_nome);
                cmd.Parameters.AddWithValue("@Ultimo_nome", func.Ultimo_nome);
                cmd.Parameters.AddWithValue("@Sexo", func.Sexo);
                cmd.Parameters.AddWithValue("@Contacto", func.Contacto);

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
                    getTabelaFuncionarios();
                    MostrarFuncionario(func.NIF);
                }
            }
            else
            {
                MessageBox.Show("Um funcionário necessita de uma loja associada");
                myForm.funcionarios1.readOnlyFuncionarios();
                getTabelaFuncionarios();
            }
        }

        // Remover funcionarios
        public void RemoveFuncionarios()
        {
            myForm.CN.Open();

            string nif = (((Funcionario)myForm.listBox7.SelectedItem).NIF);      // chave primaria

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BEGIN TRANSACTION; DELETE centro_comercial.funcionario_loja WHERE NIF = @NIF; " +
                "DELETE centro_comercial.pessoa WHERE NIF = @NIF; COMMIT;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", nif);
            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
                myForm.listBox7.Items.Remove((Funcionario)myForm.listBox7.SelectedItem);
                funcoesAux.UnlockButtons();
                funcoesAux.ClearFields();
                funcoesAux.EnableListBox();
                funcoesAux.ReadOnly();
                funcoesAux.ShowButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possível remover funcionário" + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
            }
        }

        public void SearchFuncionarios()
        {
            // Procurar pelo Nome do funcionario
            string nome = myForm.funcionarios1.getTextPrimeiroNome();

            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spGetFuncByName", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nome", nome));
            cmd.Parameters.Add(new SqlParameter("@id_centro", myForm.centroAtual));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox7.Items.Clear();

            try
            {
                while (rdr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.NIF = rdr["NIF"].ToString();
                    funcionario.Num_func = rdr["Num_func"].ToString();
                    funcionario.Contacto = rdr["Contacto"].ToString();
                    funcionario.Primeiro_nome = rdr["Primeiro_nome"].ToString();
                    funcionario.Ultimo_nome = rdr["Ultimo_nome"].ToString();
                    funcionario.Salario = rdr["Salario"].ToString();
                    funcionario.Horas_semanais = rdr["Horas_semanais"].ToString();
                    funcionario.Data_entrada = rdr["Data_de_entrada"].ToString();
                    funcionario.Nome_loja = rdr["Nome_comercial"].ToString();
                    funcionario.Numero_loja = rdr["Numero_loja"].ToString();
                    funcionario.Sexo = rdr["Sexo"].ToString();
                    myForm.listBox7.Items.Add(funcionario);
                }
                myForm.funcionarioAtual = 0;
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
            MostrarFuncionario();
        }

        public void setComboBoxLojas()
        {
            myForm.CN.Open();
            myForm.funcionarios1.comboBoxLojas.Items.Clear();
            SqlCommand cmd = new SqlCommand("spLojasByCentro", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    myForm.funcionarios1.comboBoxLojas.Items.Add(rdr["Num_loja"].ToString() + " " + rdr["Nome_comercial"].ToString());
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
    }
}
