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
    class FuncoesEventos
    {
        Form1 myForm;
        FuncoesAux funcoesAux;
        public FuncoesEventos(Form1 f)
        {
            myForm = f;
            funcoesAux = new FuncoesAux(myForm);
        }
        public void getTabelaEventos()
        {
            myForm.CN.Open();
            SqlCommand cmd = new SqlCommand("spEventos", myForm.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID_centro", myForm.textCentroID.Text));
            SqlDataReader rdr = cmd.ExecuteReader();
            myForm.listBox6.Items.Clear();
            try
            {
                while (rdr.Read())
                {
                    Evento evento = new Evento();
                    evento.Tipo = rdr["Tipo"].ToString();
                    evento.Data_inicio = rdr["Data_inicio"].ToString();
                    evento.Data_fim = rdr["Data_fim"].ToString();
                    evento.NomeDepartamento = rdr["Dep_nome"].ToString();
                    evento.ID_Departamento = rdr["ID_departamento"].ToString();
                    evento.Nome = rdr["Nome"].ToString();
                    myForm.listBox6.Items.Add(evento);
                }
                myForm.eventoAtual = 0;
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

        public void listBoxEventoAlterada()
        {
            myForm.eventoAtual = myForm.listBox6.SelectedIndex;
            MostrarEvento();
            funcoesAux.ShowButtons();
        }

        public void MostrarEvento(string nome = null)
        {
            if (nome != null)
            {
                myForm.eventoAtual = -1;
                foreach (Evento e in myForm.listBox6.Items)
                {
                    myForm.eventoAtual += 1;
                    if (e.Nome == nome)
                    {
                        myForm.listBox6.SelectedIndex = myForm.eventoAtual;
                        break;
                    }
                }
            }

            if (myForm.listBox6.Items.Count == 0 | myForm.eventoAtual < 0)
                return;
            Evento evento = new Evento();
            evento = (Evento)myForm.listBox6.Items[myForm.eventoAtual];
            myForm.eventos1.setTextNome(evento.Nome);
            myForm.eventos1.setTextTipo(evento.Tipo);
            myForm.eventos1.setTextInicio(evento.Data_inicio);
            myForm.eventos1.setTextFim(evento.Data_fim);
            myForm.eventos1.setTextDepartamento(evento.NomeDepartamento);
        }

        // Adicionar evento
        public void AddEvento()
        {
            myForm.CN.Open();
            Evento evento = new Evento();
            evento.Nome = myForm.eventos1.getNome();
            evento.Tipo = myForm.eventos1.getTipo();
            evento.Data_inicio = myForm.eventos1.getInicio();
            evento.Data_fim = myForm.eventos1.getFim();
            evento.NomeDepartamento = myForm.eventos1.getNomeDepartamento();
            evento.ID_Departamento = myForm.eventos1.getID_Departamento(myForm.textCentroID.Text);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO centro_comercial.eventos (Nome, Tipo, Data_inicio, Data_fim, ID_departamento) " + "VALUES (@Nome, @Tipo, @Data_inicio, @Data_fim, @ID_departamento)";
            cmd.Parameters.Clear();

            try
            {
                cmd.Parameters.AddWithValue("@Nome", evento.Nome);
                cmd.Parameters.AddWithValue("@Tipo", evento.Tipo);
                cmd.Parameters.AddWithValue("@ID_departamento", evento.ID_Departamento);
                cmd.Parameters.AddWithValue("@Data_inicio", DateTime.Parse(evento.Data_inicio));
                cmd.Parameters.AddWithValue("@Data_fim", DateTime.Parse(evento.Data_fim));
                cmd.Connection = myForm.CN;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                myForm.CN.Close();
                getTabelaEventos();
                MostrarEvento(evento.Nome);
            }

        }

        // Editar evento
        public void EditEvento()
        {

            myForm.CN.Open();

            Evento evento = new Evento();
            evento.Nome = myForm.eventos1.getNome();
            evento.Tipo = myForm.eventos1.getTipo();
            evento.Data_inicio = myForm.eventos1.getInicio();
            evento.Data_fim = myForm.eventos1.getFim();
            evento.NomeDepartamento = myForm.eventos1.getNomeDepartamento();
            evento.ID_Departamento = myForm.eventos1.getID_Departamento(myForm.textCentroID.Text);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE centro_comercial.eventos SET Nome = @Nome, Tipo = @Tipo, Data_inicio = @Data_inicio, Data_fim = @Data_fim, ID_departamento = @ID_departamento WHERE Nome = @Nome";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", evento.Nome);
            cmd.Parameters.AddWithValue("@Tipo", evento.Tipo);
            cmd.Parameters.AddWithValue("@Data_inicio", DateTime.Parse(evento.Data_inicio));
            cmd.Parameters.AddWithValue("@Data_fim", DateTime.Parse(evento.Data_fim));
            cmd.Parameters.AddWithValue("@ID_departamento", evento.ID_Departamento);
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
                getTabelaEventos();
                MostrarEvento(evento.Nome);
            }
        }

        // Remover evento
        public void RemoveEvento()
        {
            myForm.CN.Open();

            string nome = (((Evento)myForm.listBox6.SelectedItem).Nome);      // chave primaria

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE centro_comercial.eventos WHERE Nome=@Nome";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Connection = myForm.CN;

            try
            {
                cmd.ExecuteNonQuery();
                myForm.listBox6.Items.Remove((Evento)myForm.listBox6.SelectedItem);
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

        public void SearchEvento()
        {
            // Procurar pelo Nome do evento
            string nome = myForm.eventos1.getNome();
            MostrarEvento(nome);
        }
    }
}
