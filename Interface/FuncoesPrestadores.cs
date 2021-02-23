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
    class FuncoesPrestadores
    {
        Form1 myForm;
        FuncoesAux funcoesAux;
        public FuncoesPrestadores(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
        }
        public void getTabelaPrestadores()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spPrestadores", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox4.Items.Clear();

            try
            {
                while (rdr.Read())
                {
                    Prestador2 prestador = new Prestador2();
                    prestador.NIF = rdr["NIF"].ToString();
                    prestador.Custo_mensal = rdr["Custo_mensal"].ToString();
                    prestador.Empresa = rdr["Empresa"].ToString();
                    prestador.Horas_mensais = rdr["Horas_mensais"].ToString();
                    prestador.Servico = rdr["Servico"].ToString();
                    myForm.listBox4.Items.Add(prestador);
                }
                myForm.prestadorAtual = 0;
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

        public void listBoxPrestadorAlterada()
        {
            myForm.prestadorAtual = myForm.listBox4.SelectedIndex;
            MostrarPrestador();
            funcoesAux.ShowButtons();
        }

        public void MostrarPrestador(string nif=null)
        {
            if (nif != null)
            {
                myForm.prestadorAtual = -1;
                foreach (Prestador2 p in myForm.listBox4.Items)
                {
                    myForm.prestadorAtual += 1;
                    if (p.NIF == nif)
                    {
                        myForm.listBox4.SelectedIndex = myForm.prestadorAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox4.Items.Count == 0 | myForm.prestadorAtual < 0)
                return;
            Prestador2 prestador = new Prestador2();
            prestador = (Prestador2)myForm.listBox4.Items[myForm.prestadorAtual];
            myForm.prestadores1.setTextNIF(prestador.NIF);
            myForm.prestadores1.setTextServico(prestador.Servico);
            myForm.prestadores1.setTextEmpresa(prestador.Empresa);
            myForm.prestadores1.setTextHoras(prestador.Horas_mensais);
            myForm.prestadores1.setTextCusto(prestador.Custo_mensal);
        }



        // Adicionar prestadores
        public void AddPrestadores()
        {
            myForm.CN.Open();

            Prestador2 prt = new Prestador2();
            prt.NIF = myForm.prestadores1.getTextNIF();
            prt.Empresa = myForm.prestadores1.getTextEmpresa();
            prt.Horas_mensais = myForm.prestadores1.getTextHoras();
            prt.Servico = myForm.prestadores1.getTextServico();
            prt.Custo_mensal = myForm.prestadores1.getTextCusto();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT centro_comercial.prestador (NIF, Empresa, Horas_mensais, Servico, Custo_mensal) " + "VALUES (@NIF, @Empresa, @Horas_mensais, @Servico, @Custo_mensal) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", prt.NIF);
            cmd.Parameters.AddWithValue("@Empresa", prt.Empresa);
            cmd.Parameters.AddWithValue("@Horas_mensais", prt.Horas_mensais);
            cmd.Parameters.AddWithValue("@Servico", prt.Servico);
            cmd.Parameters.AddWithValue("@Custo_mensal", prt.Custo_mensal);
            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
                AddInterage(prt.NIF);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaPrestadores();
                MostrarPrestador(prt.NIF);
            }
        }

        // Editar prestadores
        public void EditPrestadores()
        {
            myForm.CN.Open();

            Prestador2 prt = new Prestador2();
            prt.NIF = myForm.prestadores1.getTextNIF();
            prt.Empresa = myForm.prestadores1.getTextEmpresa();
            prt.Horas_mensais = myForm.prestadores1.getTextHoras();
            prt.Servico = myForm.prestadores1.getTextServico();
            prt.Custo_mensal = myForm.prestadores1.getTextCusto();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE centro_comercial.prestador SET Empresa = @Empresa, Horas_mensais = @Horas_mensais, Servico = @Servico, Custo_mensal = @Custo_mensal WHERE NIF = @NIF";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", prt.NIF);
            cmd.Parameters.AddWithValue("@Empresa", prt.Empresa);
            cmd.Parameters.AddWithValue("@Horas_mensais", prt.Horas_mensais);
            cmd.Parameters.AddWithValue("@Servico", prt.Servico);
            cmd.Parameters.AddWithValue("@Custo_mensal", prt.Custo_mensal);

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
                getTabelaPrestadores();
                MostrarPrestador(prt.NIF);
            }
        }

        // Remover prestadores
        public void RemovePrestadores()
        {
            myForm.CN.Open();

            string nif = (((Prestador2)myForm.listBox4.SelectedItem).NIF);      // chave primaria

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE centro_comercial.prestador WHERE NIF=@NIF";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", nif);
            cmd.Connection = myForm.CN;

            try
            {
                RemoveInterage(nif);
                cmd.ExecuteNonQuery();
                myForm.listBox4.Items.Remove((Prestador2)myForm.listBox4.SelectedItem);
                funcoesAux.UnlockButtons();
                funcoesAux.ClearFields();
                funcoesAux.EnableListBox();
                funcoesAux.ReadOnly();
                funcoesAux.ShowButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
            }
        }


        // Remover interage
        public void RemoveInterage(String nif)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete centro_comercial.interage where NIF_prestador = @NIF;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", nif);
            cmd.Connection = myForm.CN;
            cmd.ExecuteNonQuery();
        }

        // Adicionar interage
        public void AddInterage(String nif)
        {
            SqlCommand cmd = new SqlCommand();
            string dep_id = myForm.textCentroID.Text + "3";
            cmd.CommandText = "INSERT centro_comercial.interage VALUES(@dep_id, @nif);";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nif", nif);
            cmd.Parameters.AddWithValue("@dep_id", dep_id);
            cmd.Connection = myForm.CN;
            cmd.ExecuteNonQuery();
        }
        public void SearchPrestador()
        {
            // Procurar pelo NIF do prestador
            string nif = myForm.prestadores1.getTextNIF();
            MostrarPrestador(nif);
        }
    }
}
