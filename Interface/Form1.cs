using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Interface
{
    public partial class Form1 : Form
    {
        public SqlConnection CN;
        FuncoesAux funcoesAux;
        FuncoesCentros funcoesCentros;
        FuncoesLojas funcoesLojas;
        FuncoesDepartamentos funcoesDepartamentos;
        FuncoesPrestadores funcoesPrestadores;
        FuncoesEmpresas funcoesEmpresas;
        FuncoesEventos funcoesEventos;
        FuncoesFuncionarios funcoesFuncionarios;
        FuncoesResp_dep funcoesResp_dep;

        private int IDNextCentro;
        public int centroAtual;
        public int lojaAtual;
        public int departamentoAtual;
        public int prestadorAtual;
        public int empresaAtual;
        public int eventoAtual;
        public int funcionarioAtual;
        public int responsavelDepartamentoAtual;
        public int lastButton;

        // Só é efetuado a 1ª vez
        public static bool calcFTFunc = true; 
        public static bool calcFTResp = true;

        // 0 - adicionar  /  1 - editar
        public int addOrEdit;      
        public int addOrEditCentro;      

        public Form1()
        {
            InitializeComponent();
            funcoesAux = new FuncoesAux(this);
            funcoesCentros = new FuncoesCentros(this);
            funcoesLojas = new FuncoesLojas(this);
            funcoesDepartamentos = new FuncoesDepartamentos(this);
            funcoesPrestadores = new FuncoesPrestadores(this);
            funcoesEmpresas = new FuncoesEmpresas(this);
            funcoesEventos = new FuncoesEventos(this);
            funcoesFuncionarios = new FuncoesFuncionarios(this);
            funcoesResp_dep = new FuncoesResp_dep(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TestaLigacaoBaseDados();
            funcoesCentros.getTabelaCentros();
        }

        private void TestaLigacaoBaseDados()
        {
            CN = new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt" + @"\" + "SQLSERVER,8101" + " ;" + "Initial Catalog = " + "p7g3" + "; uid = " + "p7g3" + ";" + "password = " + "1999migueis@Bd");
            try
            {
                CN.Open();
                setIDCentro(funcoesCentros.getIDCentro());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        // CENTROS
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                funcoesCentros.listBoxCentroAlterada();
                funcoesLojas.getTabelaLojas();
            }
        }

        // LOJAS
        private void button1_Click(object sender, EventArgs e)
        {
            departamentos1.Hide();
            prestadores1.Hide();
            eventos1.Hide();
            empresas1.Hide();
            funcionarios1.Hide();
            resp_departamentos1.Hide();
            lojas1.resetLojas();
            lojas1.Show();
            lojas1.BringToFront();
            funcoesAux.hideBtnsListBox(listBox2);
            funcoesAux.ShowAddBtn();
            lastButton = 1;     // Para adicionar/editar/remover lojas
            funcoesLojas.getTabelaLojas();
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex > -1)
            {
                funcoesLojas.listBoxLojaAlterada();
            }
        }

        // DEPARTAMENTOS
        private void button2_Click(object sender, EventArgs e)
        {
            lojas1.Hide();
            prestadores1.Hide();
            eventos1.Hide();
            empresas1.Hide();
            funcionarios1.Hide();
            resp_departamentos1.Hide();
            departamentos1.resetDepartamentos();
            departamentos1.Show();
            departamentos1.BringToFront();
            funcoesAux.hideBtnsListBox(listBox3);
            funcoesAux.ShowAddBtn();
            btnSearch.Visible = false;
            lastButton = 2;     // Para adicionar/editar/remover departamentos
            funcoesDepartamentos.getTabelaDepartamentos();
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > -1)
            {
                funcoesDepartamentos.listBoxDepartamentoAlterada();
            }
        }

        // PRESTADORES
        private void button3_Click(object sender, EventArgs e)
        {
            lojas1.Hide();
            departamentos1.Hide();
            eventos1.Hide();
            empresas1.Hide();
            funcionarios1.Hide();
            resp_departamentos1.Hide();
            prestadores1.resetPrestadores();
            prestadores1.Show();
            prestadores1.BringToFront();
            funcoesAux.hideBtnsListBox(listBox4);
            funcoesAux.ShowAddBtn();
            lastButton = 3;     // Para adicionar/editar/remover prestadores

            funcoesPrestadores.getTabelaPrestadores();
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex > -1)
            {
                funcoesPrestadores.listBoxPrestadorAlterada();
            }
        }

        // EMPRESAS
        private void button4_Click(object sender, EventArgs e)
        {
            lojas1.Hide();
            departamentos1.Hide();
            prestadores1.Hide();
            eventos1.Hide();
            funcionarios1.Hide();
            resp_departamentos1.Hide();
            empresas1.resetEmpresas();
            empresas1.Show();
            empresas1.BringToFront();
            funcoesAux.hideBtnsListBox(listBox5);
            funcoesAux.ShowAddBtn();
            lastButton = 4;     // Para adicionar/editar/remover empresas
            funcoesEmpresas.getTabelaEmpresas();
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex > -1)
            {
                funcoesEmpresas.listBoxEmpresaAlterada();
            }
        }

        // EVENTOS
        private void button5_Click(object sender, EventArgs e)
        {
            lojas1.Hide();
            departamentos1.Hide();
            prestadores1.Hide();
            empresas1.Hide();
            funcionarios1.Hide();
            resp_departamentos1.Hide();
            eventos1.resetEventos();
            eventos1.Show();
            eventos1.BringToFront();
            funcoesAux.hideBtnsListBox(listBox6);
            funcoesAux.ShowAddBtn();
            lastButton = 5;     // Para adicionar/editar/remover eventos
            funcoesEventos.getTabelaEventos();
        }
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox6.SelectedIndex > -1)
            {
                funcoesEventos.listBoxEventoAlterada();
            }
        }

        // FUNCIONARIOS
        private void button6_Click(object sender, EventArgs e)
        {
            lojas1.Hide();
            departamentos1.Hide();
            prestadores1.Hide();
            empresas1.Hide();
            eventos1.Hide();
            resp_departamentos1.Hide();
            funcionarios1.Show();
            funcionarios1.BringToFront();
            funcionarios1.resetFuncionarios();
            funcoesAux.hideBtnsListBox(listBox7);
            funcoesAux.ShowAddBtn();
            lastButton = 6;     // Para adicionar/editar/remover funcionarios
            funcoesFuncionarios.getTabelaFuncionarios();
            if (calcFTFunc)
            {
                calcFTFunc = false;
                funcionarios1.setNumFunc(funcoesFuncionarios.getNumFuncionarios());
            }

        }
        private void listBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox7.SelectedIndex > -1)
            {
                funcoesFuncionarios.listBoxFuncionarioAlterada();
            }
        }

        // RESPONSAVEIS DE DEPARTAMENTO
        private void button7_Click(object sender, EventArgs e)
        {
            lojas1.Hide();
            departamentos1.Hide();
            prestadores1.Hide();
            empresas1.Hide();
            eventos1.Hide();
            funcionarios1.Hide();
            resp_departamentos1.Show();
            resp_departamentos1.BringToFront();
            resp_departamentos1.resetResponsavel();
            funcoesAux.hideBtnsListBox(listBox8);
            funcoesAux.ShowAddBtn();
            lastButton = 7;     // Para adicionar/editar/remover funcionarios

            funcoesResp_dep.getTabelaResponsavel();
            if(calcFTResp)
            {
                calcFTResp = false;
                resp_departamentos1.setNumResp(funcoesResp_dep.getNextNumResp());
            }
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox8.SelectedIndex > -1)
            {
                funcoesResp_dep.listBoxResponsavelDepartamentoAlterada();
            }
        }

        // ADICIONAR
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addOrEdit = 0;
            funcoesAux.ClearFields();
            funcoesAux.ShowConfCancButtons();
            funcoesAux.DisableListBox();
            funcoesAux.LockButtons();
            funcoesAux.EnableWrite();
            funcoesAux.Add(lastButton);
            funcoesLojas.setComboBoxEmpresas();
            funcoesFuncionarios.setComboBoxLojas();
            if (lastButton == 2) departamentos1.setNumDep(funcoesDepartamentos.getNumDep());
            else if (lastButton == 1)
            {
                lojas1.setNumLoja(funcoesLojas.getNumLoja());
                lojas1.setTextNumLoja(lojas1.getNumLoja().ToString());
            }
        }

        // EDITAR
        private void btnEdit_Click(object sender, EventArgs e)
        {
            addOrEdit = 1;
            funcoesAux.ShowConfCancButtons();
            funcoesAux.DisableListBox();
            funcoesAux.LockButtons();
            funcoesAux.EnableWrite();
            funcoesAux.Edit(lastButton);
        }

        // REMOVER
        private void btnRemove_Click(object sender, EventArgs e)
        {
            addOrEdit = 3;
            funcoesAux.DisableListBox();
            funcoesAux.LockButtons();
            funcoesAux.ShowConfCancButtons();
        }

        // PROCURAR
        private void btnSearch_Click(object sender, EventArgs e)
        {
            addOrEdit = 2;
            funcoesAux.ShowConfCancButtons();
            funcoesAux.LockButtons();
            funcoesAux.ClearFields();
            funcoesAux.EnableWrite();
            funcoesAux.DisableListBox();
            funcoesAux.Search(lastButton);
        }

        // CONFIRMAR
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (addOrEdit == 0)
            {
                if (lastButton == 1) funcoesLojas.AddLoja();
                else if (lastButton == 2) funcoesDepartamentos.AddDepartamento();
                else if (lastButton == 3) funcoesPrestadores.AddPrestadores();
                else if (lastButton == 4) funcoesEmpresas.AddEmpresa();
                else if (lastButton == 5) funcoesEventos.AddEvento();
                else if (lastButton == 6) funcoesFuncionarios.AddFuncionarios();
                else if (lastButton == 7) funcoesResp_dep.AddResponsavel();
            }
            else if (addOrEdit == 1)
            {
                if (lastButton == 1) funcoesLojas.EditLoja();
                else if (lastButton == 2) funcoesDepartamentos.EditDepartamento();
                else if (lastButton == 3) funcoesPrestadores.EditPrestadores();
                else if (lastButton == 4) funcoesEmpresas.EditEmpresa();
                else if (lastButton == 5) funcoesEventos.EditEvento();
                else if (lastButton == 6) funcoesFuncionarios.EditFuncionarios();
                else if (lastButton == 7) funcoesResp_dep.EditResponsavel();
            }
            else if (addOrEdit == 2)
            {
                if (lastButton == 1) funcoesLojas.SearchLoja();
                else if (lastButton == 2) funcoesDepartamentos.SearchDepartamento();
                else if (lastButton == 3) funcoesPrestadores.SearchPrestador();
                else if (lastButton == 4) funcoesEmpresas.SearchEmpresa();
                else if (lastButton == 5) funcoesEventos.SearchEvento();
                else if (lastButton == 6) funcoesFuncionarios.SearchFuncionarios();
                else if (lastButton == 7) funcoesResp_dep.SearchResponsavel();
            }
            else if (addOrEdit == 3){
                if (lastButton == 1) funcoesLojas.RemoveLoja();
                else if (lastButton == 2) funcoesDepartamentos.RemoveDepartamento(((Departamento)listBox3.SelectedItem).ID);
                else if (lastButton == 3) funcoesPrestadores.RemovePrestadores();
                else if (lastButton == 4) funcoesEmpresas.RemoveEmpresa(((Empresa)listBox5.SelectedItem).NIF);
                else if (lastButton == 5) funcoesEventos.RemoveEvento();
                else if (lastButton == 6) funcoesFuncionarios.RemoveFuncionarios();
                else if (lastButton == 7) funcoesResp_dep.RemoveResponsavel();
            }

            funcoesAux.UnlockButtons();
            funcoesAux.EnableListBox();
            funcoesAux.ReadOnly();
            funcoesAux.CancelConfirm(lastButton);
            funcoesAux.ShowAddBtn();

            if (lastButton == 1 || lastButton == 4)
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.fnGetNumLojas(@ID_centro)", CN);
                cmd.Parameters.AddWithValue("@ID_centro", textCentroID.Text);
                textCentroNumeroLojas.Text = cmd.ExecuteScalar().ToString();
                CN.Close();
            }
        }

        //CANCELAR
        private void btnCancel_Click(object sender, EventArgs e)
        {
            funcoesAux.UnlockButtons();
            funcoesAux.ShowAddBtn();
            funcoesAux.EnableListBox();
            funcoesAux.ReadOnly();
            funcoesAux.CancelConfirm(lastButton);
            funcoesAux.ClearFields();
            funcoesAux.UnselectListBox();
        }

        // BOTÕES PARA O CENTRO

        // Adicionar
        private void btnAddCentro_Click(object sender, EventArgs e)
        {
            addOrEditCentro = 0;
            listBox1.SelectedIndex = -1;
            funcoesCentros.ClearFieldsCentro();
            textCentroID.Text = getIDCentro().ToString();
            funcoesCentros.EnableWriteCentro();
            funcoesCentros.ShowConfCancBtn();
            funcoesAux.DisableListBox();
            funcoesAux.LockButtons();
            funcoesAux.HideButtons();
        }

        // Editar
        private void btnEditCentro_Click(object sender, EventArgs e)
        {
            addOrEditCentro = 1;
            funcoesCentros.EnableWriteCentro();
            funcoesCentros.ShowConfCancBtn();
            funcoesAux.DisableListBox();
            funcoesAux.LockButtons();
            funcoesAux.HideButtons();
        }

        // Remover
        private void btnRemoveCentro_Click(object sender, EventArgs e)
        {
            addOrEditCentro = 2;
            funcoesAux.clearAllListBox();
            funcoesCentros.ClearItems();
            funcoesCentros.HideAll();
            funcoesAux.LockButtons();
            funcoesCentros.ResetAll();
            funcoesCentros.MostrarCentro();
            funcoesCentros.BtnVisibles();
            funcoesAux.DisableListBox();
            funcoesCentros.ReadOnlyCentro();
            funcoesCentros.ShowConfCancBtn();
            funcoesAux.HideButtons();
        }

        // Confirmar
        private void btnConfirmCentro_Click(object sender, EventArgs e)
        {
            if (addOrEditCentro == 0)
            {
                if (textCentroNome.Text == "")
                    textCentroNome.Text = "NULL";
                funcoesCentros.AddCentro();
            }    
            else if (addOrEditCentro == 1)
            {
                if (textCentroNome.Text == "")
                    textCentroNome.Text = "NULL";
                funcoesCentros.EditCentro();
            }
            else if(addOrEditCentro == 2)
                funcoesCentros.RemoveCentro();
                
            funcoesAux.clearAllListBox();
            funcoesCentros.ClearFieldsCentro();
            funcoesCentros.HideAll();
            funcoesAux.HideButtons();
            funcoesAux.UnlockButtons();
            funcoesCentros.ResetAll();
            funcoesCentros.MostrarCentro();
            funcoesCentros.BtnVisibles();
            funcoesAux.EnableListBox();
            funcoesCentros.ReadOnlyCentro();
            funcoesCentros.ShowEditRemBtn();
        }

        // Cancelar
        private void btnCancelarCentro_Click(object sender, EventArgs e)
        {
            funcoesAux.clearAllListBox();
            funcoesCentros.ClearItems();
            funcoesCentros.HideAll();
            funcoesAux.HideButtons();
            funcoesAux.LockButtons();
            funcoesCentros.ResetAll();
            funcoesCentros.MostrarCentro();
            funcoesCentros.BtnVisibles();
            funcoesAux.EnableListBox();
            funcoesCentros.ReadOnlyCentro();
            funcoesCentros.ShowAddBtn();
            funcoesCentros.ClearFieldsCentro();
            listBox1.SelectedIndex = -1;
        }

        public int getIDCentro()
        {
            return IDNextCentro;
        }
        public void setIDCentro(int value)
        {
            IDNextCentro = value;
        }
        public void updateIDCentro()
        {
            IDNextCentro += 1;
        }

       
    }
}