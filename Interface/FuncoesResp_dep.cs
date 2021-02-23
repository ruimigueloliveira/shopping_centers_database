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
    class FuncoesResp_dep
    {
        Form1 myForm;
        FuncoesAux funcoesAux;

        public FuncoesResp_dep(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
        }

        public int getNextNumResp()
        {
            myForm.CN.Open();
            var cmd = new SqlCommand("fnGetNextNumResp", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            cmd.ExecuteNonQuery();
            myForm.CN.Close();
            return (int)cmd.Parameters["@RETURN_VALUE"].Value;
        }

        public void getTabelaResponsavel()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spAdmin", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox8.Items.Clear();

            try
            {
                while (rdr.Read())
                {
                    Resp_departamento resp = new Resp_departamento();
                    resp.NIF = rdr["NIF"].ToString();
                    resp.Num_func = rdr["Num_func"].ToString();
                    resp.Salario = rdr["Salario"].ToString();
                    resp.Habilitacoes = rdr["Habilitacoes"].ToString();
                    resp.Primeiro_nome = rdr["Primeiro_nome"].ToString();
                    resp.Ultimo_nome = rdr["Ultimo_nome"].ToString();
                    resp.Sexo = rdr["Sexo"].ToString();
                    resp.Contacto = rdr["Contacto"].ToString();
                    resp.ID_centro = rdr["ID_centro"].ToString();
                    resp.Departamento = rdr["Nome"].ToString();
                    myForm.listBox8.Items.Add(resp);
                }
                myForm.responsavelDepartamentoAtual = 0;
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

        public void listBoxResponsavelDepartamentoAlterada()
        {
            myForm.responsavelDepartamentoAtual = myForm.listBox8.SelectedIndex;
            MostrarResponsavel();
            funcoesAux.ShowButtons();
        }

        public void MostrarResponsavel(string nif = null)
        {
            if (nif != null)
            {
                myForm.responsavelDepartamentoAtual = -1;
                foreach (Resp_departamento r in myForm.listBox8.Items)
                {
                    myForm.responsavelDepartamentoAtual += 1;
                    if (r.NIF == nif)
                    {
                        myForm.listBox8.SelectedIndex = myForm.responsavelDepartamentoAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox8.Items.Count == 0 | myForm.responsavelDepartamentoAtual < 0)
                return;
            Resp_departamento resp = new Resp_departamento();
            resp = (Resp_departamento)myForm.listBox8.Items[myForm.responsavelDepartamentoAtual];
            myForm.resp_departamentos1.setTextNIF(resp.NIF);
            myForm.resp_departamentos1.setTextNumeroFunc(resp.Num_func);
            myForm.resp_departamentos1.setTextSalario(resp.Salario);
            myForm.resp_departamentos1.setTextHabilitacoes(resp.Habilitacoes);
            myForm.resp_departamentos1.setTextPrimeiroNome(resp.Primeiro_nome);
            myForm.resp_departamentos1.setTextUltimoNome(resp.Ultimo_nome);
            myForm.resp_departamentos1.setTextSexo(resp.Sexo);
            myForm.resp_departamentos1.setTextContacto(resp.Contacto);
            myForm.resp_departamentos1.setTextDepartamento(resp.Departamento);
        }

        // Adicionar responsavel de departamento
        public void AddResponsavel()
        {
            myForm.CN.Open();

            Resp_departamento resp = new Resp_departamento();
            resp.NIF = myForm.resp_departamentos1.getTextNIF();
            resp.Num_func = myForm.resp_departamentos1.getTextNumeroFunc();
            resp.Contacto = myForm.resp_departamentos1.getTextContacto();
            resp.Primeiro_nome = myForm.resp_departamentos1.getTextPrimeiroNome();
            resp.Ultimo_nome = myForm.resp_departamentos1.getTextUltimoNome();
            resp.Salario = myForm.resp_departamentos1.getTextSalario();
            resp.Habilitacoes = myForm.resp_departamentos1.getTextHabilitacoes();
            resp.Sexo = myForm.resp_departamentos1.getTextSexo();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BEGIN TRANSACTION; INSERT centro_comercial.pessoa(Primeiro_nome, Ultimo_nome, Sexo, Contacto, NIF) VALUES(@Primeiro_nome, @Ultimo_nome, @Sexo, @Contacto, @NIF)" +
                "INSERT centro_comercial.responsavel_departamento (NIF, Salario, Habilitacoes, Num_func, ID_centro) VALUES (@NIF, @Salario, @Habilitacoes, @Num_func, @ID_centro); COMMIT;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Num_func", resp.Num_func);
            cmd.Parameters.AddWithValue("@NIF", resp.NIF);
            cmd.Parameters.AddWithValue("@Salario", resp.Salario);
            cmd.Parameters.AddWithValue("@Primeiro_nome", resp.Primeiro_nome);
            cmd.Parameters.AddWithValue("@Ultimo_nome", resp.Ultimo_nome);
            cmd.Parameters.AddWithValue("@Sexo", resp.Sexo);
            cmd.Parameters.AddWithValue("@Contacto", resp.Contacto);
            cmd.Parameters.AddWithValue("@Habilitacoes", resp.Habilitacoes);
            cmd.Parameters.AddWithValue("@ID_centro", myForm.textCentroID.Text);

            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
                myForm.resp_departamentos1.updateNumResp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaResponsavel();
                MostrarResponsavel(resp.Num_func);
            }
        }

        // Editar funcionarios
        public void EditResponsavel()
        {
            myForm.CN.Open();

            Resp_departamento resp = new Resp_departamento();
            resp.NIF = myForm.resp_departamentos1.getTextNIF();
            resp.Num_func = myForm.resp_departamentos1.getTextNumeroFunc();
            resp.Contacto = myForm.resp_departamentos1.getTextContacto();
            resp.Primeiro_nome = myForm.resp_departamentos1.getTextPrimeiroNome();
            resp.Ultimo_nome = myForm.resp_departamentos1.getTextUltimoNome();
            resp.Salario = myForm.resp_departamentos1.getTextSalario();
            resp.Habilitacoes = myForm.resp_departamentos1.getTextHabilitacoes();
            resp.Sexo = myForm.resp_departamentos1.getTextSexo();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BEGIN TRANSACTION; UPDATE centro_comercial.responsavel_departamento SET NIF = @NIF, Habilitacoes = @Habilitacoes, Salario = @Salario WHERE Num_func = @Num_func; " +
                "UPDATE centro_comercial.pessoa SET Primeiro_nome = @Primeiro_nome, Ultimo_nome = @Ultimo_nome, Sexo = @Sexo, Contacto = @Contacto WHERE NIF = @NIF; COMMIT;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Num_func", resp.Num_func);
            cmd.Parameters.AddWithValue("@NIF", resp.NIF);
            cmd.Parameters.AddWithValue("@Salario", resp.Salario);
            cmd.Parameters.AddWithValue("@Primeiro_nome", resp.Primeiro_nome);
            cmd.Parameters.AddWithValue("@Ultimo_nome", resp.Ultimo_nome);
            cmd.Parameters.AddWithValue("@Sexo", resp.Sexo);
            cmd.Parameters.AddWithValue("@Contacto", resp.Contacto);
            cmd.Parameters.AddWithValue("@Habilitacoes", resp.Habilitacoes);

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
                getTabelaResponsavel();
                MostrarResponsavel(resp.Num_func);
            }
        }

        // Remover funcionarios
        public void RemoveResponsavel()
        {
            myForm.CN.Open();

            string nif = (((Resp_departamento)myForm.listBox8.SelectedItem).NIF);      // chave primaria

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BEGIN TRANSACTION; DELETE centro_comercial.responsavel_departamento WHERE NIF = @NIF; " +
                "DELETE centro_comercial.pessoa WHERE NIF = @NIF; COMMIT;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", nif);
            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
                myForm.listBox8.Items.Remove((Resp_departamento)myForm.listBox8.SelectedItem);
                funcoesAux.UnlockButtons();
                funcoesAux.ClearFields();
                funcoesAux.EnableListBox();
                funcoesAux.ReadOnly();
                funcoesAux.ShowButtons();
            }
            catch (Exception)
            {
                MessageBox.Show("Impossivel remover responsavel pois este está encarregue de um departamento");
            }
            finally
            {
                myForm.CN.Close();
            }
        }

        public void SearchResponsavel()
        {
            // Procurar pelo NIF do responsavel
            string nif = myForm.resp_departamentos1.getTextNIF();
            MostrarResponsavel(nif);
        }
    }
}
