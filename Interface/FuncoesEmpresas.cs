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
    class FuncoesEmpresas
    {
        Form1 myForm;
        FuncoesAux funcoesAux;
        public FuncoesEmpresas(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
        }
        public void getTabelaEmpresas()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spEmpresas", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox5.Items.Clear();

            try
            {
                while (rdr.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.Nome = rdr["Nome"].ToString();
                    empresa.NIF = rdr["NIF"].ToString();
                    empresa.Contacto = rdr["Contacto"].ToString();
                    myForm.listBox5.Items.Add(empresa);
                }
                myForm.empresaAtual = 0;
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

        public void listBoxEmpresaAlterada()
        {
            myForm.empresaAtual = myForm.listBox5.SelectedIndex;
            myForm.empresas1.listBox1.Items.Clear();
            MostrarEmpresa();
            funcoesAux.ShowButtons();
        }

        public void MostrarEmpresa(string nif=null)
        {
            if (nif != null)
            {
                myForm.empresaAtual = -1;
                foreach (Empresa e in myForm.listBox5.Items)
                {
                    myForm.empresaAtual += 1;
                    if (e.NIF == nif)
                    {
                        myForm.listBox5.SelectedIndex = myForm.empresaAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox5.Items.Count == 0 | myForm.empresaAtual < 0)
                return;
            Empresa empresa = new Empresa();
            empresa = (Empresa)myForm.listBox5.Items[myForm.empresaAtual];
            myForm.empresas1.setTextNome(empresa.Nome);
            myForm.empresas1.setTextNIF(empresa.NIF);
            myForm.empresas1.setTextContacto(empresa.Contacto);

            SqlCommand sqlcmd3 = new SqlCommand("select distinct centro_comercial.loja.Nome_comercial from centro_comercial.empresa join centro_comercial.loja on NIF = NIF_empresa where NIF = " + myForm.empresas1.getTextNIF(), myForm.CN);
            myForm.CN.Open();
            setListBoxLojas(empresa.NIF);
            myForm.CN.Close();
        }

        // Adicionar empresa
        public void AddEmpresa()
        {
            myForm.CN.Open();

            Empresa emp = new Empresa();
            emp.NIF = myForm.empresas1.getTextNIF();
            emp.Nome = myForm.empresas1.getTextNome();
            emp.Contacto = myForm.empresas1.getTextContacto();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT centro_comercial.EMPRESA (NIF, Nome, Contacto) " + "VALUES (@NIF, @Nome, @Contacto) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", emp.NIF);
            cmd.Parameters.AddWithValue("@Nome", emp.Nome);
            cmd.Parameters.AddWithValue("@Contacto", emp.Contacto);
            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
                AddComunica(emp.NIF);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaEmpresas();
                MostrarEmpresa(emp.NIF);
            }
        }

        // Editar empresa
        public void EditEmpresa()
        {
            myForm.CN.Open();

            Empresa emp = new Empresa();
            emp.NIF = myForm.empresas1.getTextNIF();
            emp.Nome = myForm.empresas1.getTextNome();
            emp.Contacto = myForm.empresas1.getTextContacto();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE centro_comercial.Empresa " + "SET Nome = @Nome, " + "Contacto = @Contacto " + "WHERE NIF = @NIF";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", emp.NIF);
            cmd.Parameters.AddWithValue("@Nome", emp.Nome);
            cmd.Parameters.AddWithValue("@Contacto", emp.Contacto);
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
                getTabelaEmpresas();
                MostrarEmpresa(emp.NIF);
            }
        }

        // Remover empresa
        public void RemoveEmpresa(string nif)
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spDelLojasEmpresa", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NIF_empresa", nif));
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));

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
                getTabelaEmpresas();
                MostrarEmpresa();
                funcoesAux.UnlockButtons();
                funcoesAux.ClearFields();
                funcoesAux.ReadOnly();
                funcoesAux.ShowAddBtn();
            }
        }

        // Adicionar comunica
        public void AddComunica(String nif)
        {
            SqlCommand cmd = new SqlCommand();
            string dep_id = myForm.textCentroID.Text + "2";
            cmd.CommandText = "INSERT centro_comercial.comunica VALUES(@dep_id, @nif);";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nif", nif);
            cmd.Parameters.AddWithValue("@dep_id", dep_id);
            cmd.Connection = myForm.CN;
            cmd.ExecuteNonQuery();
        }

        public void SearchEmpresa()
        {
            // Procurar pelo NIF da empresa
            string nif = myForm.empresas1.getTextNIF();
            MostrarEmpresa(nif);
        }

        public void setListBoxLojas(string NIF_empresa)
        {
            myForm.empresas1.listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("spLojasList", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NIF_empresa", NIF_empresa));
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    myForm.empresas1.listBox1.Items.Add(rdr["Nome_comercial"]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }
    }
}
